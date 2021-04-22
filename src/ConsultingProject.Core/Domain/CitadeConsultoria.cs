using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultingProject.Core.Domain
{
    public class Cita
    {
        [Key]
        public int id_citaconsultoria { get; set; }
        public string Empresa { get; set; }
        public string Asunto { get; set; }
        public DateTime Fechayhora { get; set; }
        public string Lugar { get; set; }
        public string Invitar_Correo { get; set; }
    }
}
