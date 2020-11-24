using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Actividades = new HashSet<Actividades>();
            EjeSeleccionado = new HashSet<EjeSeleccionado>();
            Empresa = new HashSet<Empresa>();
            Etapas = new HashSet<Etapas>();
            Profesional = new HashSet<Profesional>();
        }

        public string IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string NoConvenio { get; set; }
        public string Objeto { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? PlazoEjecucion { get; set; }
        public int? Presupuesto { get; set; }

        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<EjeSeleccionado> EjeSeleccionado { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Etapas> Etapas { get; set; }
        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
