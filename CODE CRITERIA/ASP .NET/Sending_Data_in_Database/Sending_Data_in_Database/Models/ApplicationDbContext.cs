using Microsoft.EntityFrameworkCore;

namespace Sending_Data_in_Database.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
    }
}
