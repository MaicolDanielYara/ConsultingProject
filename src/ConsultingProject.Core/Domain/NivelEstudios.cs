using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class NivelEstudios
    {
        public string IdNivelEstudio { get; set; }
        public string NivelEstudio { get; set; }
    }
}
