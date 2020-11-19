using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class EjeSeleccionado
    {
        public EjeSeleccionado()
        {
            Empresa = new HashSet<Empresa>();
        }

        public string IdEje { get; set; }
        public string Eje { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
