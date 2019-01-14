using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFSkillRepository : ISkillRepository
    {
        public IQueryable<TSkill> Items => context.TSkill;
        private CodiJobDbContext context;
        public EFSkillRepository(CodiJobDbContext ctx)
        {
            this.context = ctx;
        }
        public void Save(TSkill skill)
        {
            if (skill.SkillId == Guid.Empty)
            {
                skill.SkillId = Guid.NewGuid();
                context.TSkill.Add(skill);
            }
            else
            {
                TSkill dbEntry = context.TSkill
                .FirstOrDefault(p => p.SkillId == skill.SkillId);
                if (dbEntry != null)
                {
                    dbEntry.SkillId = skill.SkillId;
                   
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid SkillId)
        {
            TSkill dbEntry = context.TSkill
            .FirstOrDefault(p => p.SkillId == SkillId);
            if (dbEntry != null)
            {
                context.TSkill.Remove(dbEntry);
                context.SaveChanges();
            }
        }
       
    }
}
