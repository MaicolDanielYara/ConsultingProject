using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empresa = new HashSet<Empresa>();
            Municipio = new HashSet<Municipio>();
        }

        public int CódigoDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
