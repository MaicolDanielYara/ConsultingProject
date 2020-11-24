using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Actividades
    {
        public string IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public string IdEtapa { get; set; }
        public string IdProyecto { get; set; }
        public string IdProfesional { get; set; }

        public virtual Etapas IdEtapaNavigation { get; set; }
        public virtual Profesional IdProfesionalNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
    }
}
