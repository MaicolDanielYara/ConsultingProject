using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class Profesiones
    {
        public string IdProfesion { get; set; }
        public string Profesion { get; set; }
    }
}
