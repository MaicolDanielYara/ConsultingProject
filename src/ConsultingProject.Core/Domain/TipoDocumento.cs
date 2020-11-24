using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Profesional = new HashSet<Profesional>();
            RepresentanteLegal = new HashSet<RepresentanteLegal>();
        }

        public int IdTipoDocumento { get; set; }
        public string TipoDeDocumento { get; set; }

        public virtual ICollection<Profesional> Profesional { get; set; }
        public virtual ICollection<RepresentanteLegal> RepresentanteLegal { get; set; }
    }
}
