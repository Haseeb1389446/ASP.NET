using Microsoft.EntityFrameworkCore;

namespace Db_Connection.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> tbl_Students { get; set; }
    }
}
