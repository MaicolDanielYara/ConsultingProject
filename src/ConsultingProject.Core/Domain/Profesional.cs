using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Profesional
    {
        public Profesional()
        {
            Actividades = new HashSet<Actividades>();
            Empresa = new HashSet<Empresa>();
            Usuario = new HashSet<Usuario>();
        }

        public string IdProfesional { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public int NoDocumento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string IdProfesion { get; set; }
        public string IdEstudio { get; set; }
        public string IdCargo { get; set; }
        public string IdProyecto { get; set; }
        public string IdEje { get; set; }

        public virtual Cargos IdCargoNavigation { get; set; }
        public virtual EjeSeleccionado IdEjeNavigation { get; set; }
        public virtual Estudios IdEstudioNavigation { get; set; }
        public virtual Profesiones IdProfesionNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
