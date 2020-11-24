using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Profesiones
    {
        public Profesiones()
        {
            Profesional = new HashSet<Profesional>();
        }

        public string IdProfesion { get; set; }
        public string Profesion { get; set; }

        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
