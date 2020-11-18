using System;
using System.Collections.Generic;

namespace ConsultingProject.Web
{
    public partial class TamañoEmpresa
    {
        public TamañoEmpresa()
        {
            Empresa = new HashSet<Empresa>();
        }

        public string IdTamañoEmpresa { get; set; }
        public string TamañoEmpresa1 { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
