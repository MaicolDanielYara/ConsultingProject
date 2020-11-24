using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Usuario
    {
        public string IdUsuario { get; set; }
        public string NoDocumento { get; set; }
        public string Contraseña { get; set; }
        public string IdProfesional { get; set; }
        public string IdRol { get; set; }

        public virtual Profesional IdProfesionalNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
