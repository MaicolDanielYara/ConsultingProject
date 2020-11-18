using System;
using System.Collections.Generic;

namespace ConsultingProject.Web
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Empresa = new HashSet<Empresa>();
        }

        public string IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string NoConvenio { get; set; }
        public string Objeto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? PlazoEjecucion { get; set; }
        public int? Presupuesto { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
