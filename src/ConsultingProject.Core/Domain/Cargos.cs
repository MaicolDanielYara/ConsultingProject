using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Cargos
    {
        public Cargos()
        {
            Profesional = new HashSet<Profesional>();
        }

        public string IdCargo { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
