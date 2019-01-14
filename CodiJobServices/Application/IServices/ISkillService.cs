using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface ISkillService
    {
        void Insert(SkillDTO entityDTO);

        IList<SkillDTO> GetAll();

        void Update(SkillDTO entityDTO);

        void Delete(Guid entityId);
    }
}
