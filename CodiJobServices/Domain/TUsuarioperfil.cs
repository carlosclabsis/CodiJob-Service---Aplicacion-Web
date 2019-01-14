using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TUsuarioperfil
    {
        public TUsuarioperfil()
        {
            TUsuariogrupo = new HashSet<TUsuariogrupo>();
            TUsuarioproyecto = new HashSet<TUsuarioproyecto>();
            TUsuskill = new HashSet<TUsuskill>();
        }

        public Guid UsuperId { get; set; }
        public string UsuperDesc { get; set; }
        public string UsuperGit { get; set; }
        public string UsuperBlog { get; set; }
        public string UsuperWeb { get; set; }

        public ICollection<TUsuariogrupo> TUsuariogrupo { get; set; }
        public ICollection<TUsuarioproyecto> TUsuarioproyecto { get; set; }
        public ICollection<TUsuskill> TUsuskill { get; set; }
    }
}
