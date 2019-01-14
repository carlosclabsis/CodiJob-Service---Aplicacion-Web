using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        public IQueryable<TProyecto> Items => context.TProyecto;
        private CodiJobDbContext context;
        public EFProyectoRepository(CodiJobDbContext ctx)
        {
            this.context = ctx;
        }
        public void Save(TProyecto proyecto)
        {
            if (proyecto.ProyId == Guid.Empty)
            {
                proyecto.ProyId = Guid.NewGuid();
                context.TProyecto.Add(proyecto);
            }
            else
            {
                TProyecto dbEntry = context.TProyecto
                    .FirstOrDefault(p => p.ProyId == proyecto.ProyId);
                if (dbEntry != null)
                {
                    dbEntry.ProyNom = proyecto.ProyNom;
                    dbEntry.ProyDesc = proyecto.ProyDesc;
                    dbEntry.ProyFecha = proyecto.ProyFecha;
                    dbEntry.ProyUrl = proyecto.ProyUrl;
                }

                StringBuilder hex1 = new StringBuilder(dbEntry.RowVersion.Length * 2);
                StringBuilder hex2 = new StringBuilder(proyecto.RowVersion.Length * 2);
                foreach (byte b in dbEntry.RowVersion)
                    hex1.AppendFormat("{0:x2}", b);
                var version1 = hex1.ToString();

                foreach (byte b in proyecto.RowVersion)
                    hex2.AppendFormat("{0:x2}", b);
                var version2 = hex2.ToString();
                if (version1 == version2)
                {
                    dbEntry.ProyNom = proyecto.ProyNom;
                    dbEntry.ProyDesc = proyecto.ProyDesc;
                    dbEntry.ProyFecha = proyecto.ProyFecha;
                    dbEntry.ProyUrl = proyecto.ProyUrl;
                }
                else
                {
                    throw new Exception("this entity was modified already, Please retrieve this Entity again.");
                }


            }
                
            context.SaveChangesAsync();
        }
        public void Delete(Guid ProyectoID)
        {
            TProyecto dbEntry = context.TProyecto
            .FirstOrDefault(p => p.ProyId == ProyectoID);
            if (dbEntry != null)
            {
                context.TProyecto.Remove(dbEntry);
                context.SaveChanges();
            }
        }
        public IQueryable<TProyecto> FilterProyectos(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }
    }
}
