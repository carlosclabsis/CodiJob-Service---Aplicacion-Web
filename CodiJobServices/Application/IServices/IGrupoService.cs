using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IGrupoService
    {
        void Insert(GrupoDTO entityDTO);

        IList<GrupoDTO> GetAll();

        void Update(GrupoDTO entityDTO);

        void Delete(Guid entityId);
    }
}
