using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public string IdRol { get; set; }
        public string NombreRol { get; set; }
        public string DescripciónRol { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
