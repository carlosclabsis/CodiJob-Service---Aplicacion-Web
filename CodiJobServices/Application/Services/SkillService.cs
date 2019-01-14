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
    public class SkillService : ISkillService
    {
        ISkillRepository repository;

        public SkillService(ISkillRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<SkillDTO> GetAll()
        {
            IQueryable<TSkill> skillEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<SkillDTO, TSkill>(skillEntities);
        }
        public void Insert(SkillDTO entityDTO)
        {
            TSkill entity = Builders.GenericBuilder.builderDTOEntity<TSkill, SkillDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(SkillDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TSkill, SkillDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
