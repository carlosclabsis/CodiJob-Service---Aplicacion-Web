using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TSkill
    {
        public TSkill()
        {
            TUsuskill = new HashSet<TUsuskill>();
        }

        public Guid SkillId { get; set; }
        public string SkillNom { get; set; }

        public ICollection<TUsuskill> TUsuskill { get; set; }
    }
}
