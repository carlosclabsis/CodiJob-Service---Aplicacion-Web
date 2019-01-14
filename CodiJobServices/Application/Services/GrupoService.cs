using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class GrupoService : IGrupoService
    {
        IGrupoRepository repository;

        public GrupoService(IGrupoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<GrupoDTO> GetAll()
        {
            IQueryable<TGrupo> gruposEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<GrupoDTO, TGrupo>(gruposEntities);
        }
        public void Insert(GrupoDTO entityDTO)
        {
            TGrupo entity = Builders.GenericBuilder.builderDTOEntity<TGrupo, GrupoDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(GrupoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TGrupo, GrupoDTO>(entityDTO);
            repository.Save(entity);
        }

    }
}
