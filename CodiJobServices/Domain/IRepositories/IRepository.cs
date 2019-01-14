using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        void Save(TEntity item);
        void Delete(Guid itemId);
       

    }
}
