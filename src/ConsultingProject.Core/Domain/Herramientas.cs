using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Herramientas
    {
        public string IdHerramienta { get; set; }
        public string Herramienta { get; set; }
        public string IdEje { get; set; }

        public virtual EjeSeleccionado IdEjeNavigation { get; set; }
    }
}
