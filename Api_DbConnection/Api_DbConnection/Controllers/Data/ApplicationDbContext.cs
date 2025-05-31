using Microsoft.EntityFrameworkCore;

namespace Api_DbConnection.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

        public DbSet<Student> students { get; set; }
    }
}
