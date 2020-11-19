using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class Cargos
    {
        public string IdCargo { get; set; }
        public string Cargo { get; set; }
    }
}
