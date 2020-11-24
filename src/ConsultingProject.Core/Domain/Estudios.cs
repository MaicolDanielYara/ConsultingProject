using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Estudios
    {
        public Estudios()
        {
            Profesional = new HashSet<Profesional>();
        }

        public string IdEstudio { get; set; }
        public string Estudio { get; set; }

        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
