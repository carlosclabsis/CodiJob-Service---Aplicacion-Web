using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFGrupoRepository : IGrupoRepository
    {
        public IQueryable<TGrupo> Items => context.TGrupo;
        private CodiJobDbContext context;
        public EFGrupoRepository(CodiJobDbContext ctx)
        {
            this.context = ctx;
        }
        public void Save(TGrupo grupo)
        {
            if (grupo.Id == Guid.Empty)
            {
                grupo.Id = Guid.NewGuid();
                context.TGrupo.Add(grupo);
            }
            else
            {
                TGrupo dbEntry = context.TGrupo
                .FirstOrDefault(p => p.Id == grupo.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = grupo.Id;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid GrupoId)
        {
            TGrupo dbEntry = context.TGrupo
            .FirstOrDefault(p => p.Id == GrupoId);
            if (dbEntry != null)
            {
                context.TGrupo.Remove(dbEntry);
                context.SaveChanges();
            }
        }
     
    }
}
