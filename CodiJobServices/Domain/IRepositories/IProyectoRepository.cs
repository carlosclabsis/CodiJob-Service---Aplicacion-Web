using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IProyectoRepository : IRepository<TProyecto>
    {
        IQueryable<TProyecto> FilterProyectos(int pageSize, int page);
    }
}
