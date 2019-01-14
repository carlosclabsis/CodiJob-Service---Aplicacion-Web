using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IUsuarioperfilService
    {
        void Insert(UsuarioperfilDTO entityDTO);

        IList<UsuarioperfilDTO> GetAll();

        void Update(UsuarioperfilDTO entityDTO);

        void Delete(Guid entityId);

        UsuarioperfilDTO GetUsuarioPerfil(Guid entityId);
    }
}
