using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TUsuariogrupo
    {
        public Guid UsugrupoId { get; set; }
        public Guid UsuId { get; set; }
        public Guid GrupoId { get; set; }

        public TGrupo Grupo { get; set; }
        public TUsuarioperfil Usu { get; set; }
    }
}
