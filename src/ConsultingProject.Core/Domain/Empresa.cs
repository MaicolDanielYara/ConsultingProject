using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public int? Nit { get; set; }
        public int? DigitoVerificacion { get; set; }
        public DateTime? Fechaconstlegal { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Sector { get; set; }
        public string IdTamañoEmpresa { get; set; }
        public string IdEje { get; set; }
        public int NoDocumentoRl { get; set; }
        public string IdProyecto { get; set; }

        public virtual EjeSeleccionado IdEjeNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual TamañoEmpresa IdTamañoEmpresaNavigation { get; set; }
        public virtual RepresentanteLegal NoDocumentoRlNavigation { get; set; }
    }
}
