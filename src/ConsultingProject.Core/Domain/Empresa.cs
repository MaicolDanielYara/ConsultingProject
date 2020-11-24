using System;
using System.Collections.Generic;

namespace ConsultingProject.Core.Domain
{
    public partial class Empresa
    {
        public Empresa()
        {
            RepresentanteLegal = new HashSet<RepresentanteLegal>();
        }

        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int? Nit { get; set; }
        public int? DigitoVerificacion { get; set; }
        public DateTime? Fechaconstlegal { get; set; }
        public int CódigoDepartamento { get; set; }
        public int CódigoMunicipio { get; set; }
        public string IdSector { get; set; }
        public string IdTamañoEmpresa { get; set; }
        public string IdEje { get; set; }
        public string IdProyecto { get; set; }
        public string IdProfesional { get; set; }

        public virtual Departamento CódigoDepartamentoNavigation { get; set; }
        public virtual Municipio CódigoMunicipioNavigation { get; set; }
        public virtual EjeSeleccionado IdEjeNavigation { get; set; }
        public virtual Profesional IdProfesionalNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual TamañoEmpresa IdTamañoEmpresaNavigation { get; set; }
        public virtual ICollection<RepresentanteLegal> RepresentanteLegal { get; set; }
    }
}
