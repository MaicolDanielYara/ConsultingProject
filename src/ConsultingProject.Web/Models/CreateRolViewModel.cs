using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultingProject.Web.Models
{
    public class CreateRolViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
