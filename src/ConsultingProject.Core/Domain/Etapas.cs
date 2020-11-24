using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Etapas
    {
        public Etapas()
        {
            Actividades = new HashSet<Actividades>();
        }

        public string IdEtapa { get; set; }
        public string NombreEtapa { get; set; }
        public string DescripcionEtapa { get; set; }
        public string IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}
