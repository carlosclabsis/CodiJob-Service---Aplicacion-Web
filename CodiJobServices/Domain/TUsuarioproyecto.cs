using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TUsuarioproyecto
    {
        public Guid UsuproId { get; set; }
        public Guid UsuId { get; set; }
        public Guid ProyId { get; set; }

        public TProyecto Proy { get; set; }
        public TUsuarioperfil Usu { get; set; }
    }
}
