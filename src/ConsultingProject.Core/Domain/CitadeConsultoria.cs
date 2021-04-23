using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultingProject.Core.Domain
{
    [Table ("citaconsultoria")]
    public class Citaconsultoria
    {
        [Key]
        [Required]
        public int Id_citaconsultoria { get; set; }
        [Required]
        [StringLength (50)]
        public string Empresa { get; set; }
        [Required]
        [StringLength(200)]
        public string Asunto { get; set; }
        [Required]
        public DateTime Fechayhora { get; set; }
        [Required]
        [StringLength(65)]
        public string Lugar { get; set; }
        [Required]
        [StringLength(40)]
        public string Invitar_Correo { get; set; }
    }
}
