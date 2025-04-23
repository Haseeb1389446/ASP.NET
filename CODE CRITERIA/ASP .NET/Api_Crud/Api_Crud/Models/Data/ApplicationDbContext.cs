using Microsoft.EntityFrameworkCore;

namespace Api_Crud.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

        public DbSet<Student> students { get; set; }
    }
}
