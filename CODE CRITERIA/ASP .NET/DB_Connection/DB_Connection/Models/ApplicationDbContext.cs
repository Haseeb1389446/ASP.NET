using Microsoft.EntityFrameworkCore;

namespace DB_Connection.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        DbSet<Student> tbl_students { get; set; }
    }
}
