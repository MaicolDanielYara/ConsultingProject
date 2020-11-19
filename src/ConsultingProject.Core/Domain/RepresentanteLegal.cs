using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class RepresentanteLegal
    {
        public string NombresRepresentanteLegal { get; set; }
        public string ApellidosRepresentanteLegal { get; set; }
        public string TipoDocumento { get; set; }
        public int NoDocumentoRl { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
