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
    public class UsuarioperfilService : IUsuarioperfilService
    {
        IUsuarioperfilRepository repository;

        public UsuarioperfilService(IUsuarioperfilRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public UsuarioperfilDTO GetUsuarioPerfil(Guid Id)
        {
            var entity = repository.Items.Where(p => p.UsuperId == Id).FirstOrDefault();
            return Builders.
                GenericBuilder.
                builderEntityDTO<UsuarioperfilDTO, TUsuarioperfil>
                (entity);
        }
        public IList<UsuarioperfilDTO> GetAll()
        {
            IQueryable<TUsuarioperfil> gruposEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<UsuarioperfilDTO, TUsuarioperfil>(gruposEntities);
        }
        public void Insert(UsuarioperfilDTO entityDTO)
        {
            TUsuarioperfil entity = Builders.GenericBuilder.builderDTOEntity<TUsuarioperfil, UsuarioperfilDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(UsuarioperfilDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TUsuarioperfil, UsuarioperfilDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
