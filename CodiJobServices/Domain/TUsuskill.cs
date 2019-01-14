using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TUsuskill
    {
        public Guid UsuskillId { get; set; }
        public Guid UsuId { get; set; }
        public Guid SkillId { get; set; }
        public string UsuskillNivel { get; set; }
        public bool? UsuskillVeri { get; set; }

        public TSkill Skill { get; set; }
        public TUsuarioperfil Usu { get; set; }
    }
}
