using Microsoft.EntityFrameworkCore;


namespace ConsultingProject.Infrastructure.Data
{
    public class ConsultingProjectDbContext : DbContext
    {
        public ConsultingProjectDbContext(DbContextOptions<ConsultingProjectDbContext> options) : base(options)
        {

        }
    }
}
