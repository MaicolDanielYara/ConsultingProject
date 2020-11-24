using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Sector
    {
        public Sector()
        {
            Empresa = new HashSet<Empresa>();
        }

        public string IdSector { get; set; }
        public string Sector1 { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
