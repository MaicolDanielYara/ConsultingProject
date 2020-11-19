using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingProject.Core.Domain
{
    public partial class Efmigrationshistory
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
