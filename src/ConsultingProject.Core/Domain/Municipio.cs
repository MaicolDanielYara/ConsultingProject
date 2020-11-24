using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Municipio
    {
        public Municipio()
        {
            Empresa = new HashSet<Empresa>();
        }

        public int CódigoMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public int CódigoDepartamento { get; set; }

        public virtual Departamento CódigoDepartamentoNavigation { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
