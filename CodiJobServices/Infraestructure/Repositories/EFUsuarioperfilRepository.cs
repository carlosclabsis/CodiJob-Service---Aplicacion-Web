using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.Repositories
{
    public class EFUsuarioperfilRepository : IUsuarioperfilRepository
    {
        public IQueryable<TUsuarioperfil> Items => context.TUsuarioperfil;
        private CodiJobDbContext context;
       
        public EFUsuarioperfilRepository(CodiJobDbContext ctx)
        {
            this.context = ctx;
        }
        public void Save(TUsuarioperfil usuario)
        {
            if (usuario.UsuperId == Guid.Empty)
            {
                usuario.UsuperId = Guid.NewGuid();
                context.TUsuarioperfil.Add(usuario);
            }
            else
            {
                TUsuarioperfil dbEntry = context.TUsuarioperfil
                .FirstOrDefault(p => p.UsuperId == usuario.UsuperId);
                if (dbEntry != null)
                {
                    dbEntry.UsuperBlog = usuario.UsuperBlog;
                    dbEntry.UsuperDesc = usuario.UsuperDesc;
                    dbEntry.UsuperGit = usuario.UsuperGit;
                    dbEntry.UsuperWeb = usuario.UsuperWeb;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid UsuperId)
        {
            TUsuarioperfil dbEntry = context.TUsuarioperfil
            .FirstOrDefault(p => p.UsuperId == UsuperId);
            if (dbEntry != null)
            {
                context.TUsuarioperfil.Remove(dbEntry);
                context.SaveChanges();
            }
        }
        

    }
}
