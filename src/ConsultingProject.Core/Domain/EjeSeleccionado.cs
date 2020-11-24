using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class EjeSeleccionado
    {
        public EjeSeleccionado()
        {
            Empresa = new HashSet<Empresa>();
            Herramientas = new HashSet<Herramientas>();
            Profesional = new HashSet<Profesional>();
        }

        public string IdEje { get; set; }
        public string Eje { get; set; }
        public string IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Herramientas> Herramientas { get; set; }
        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
