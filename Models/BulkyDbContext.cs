using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Models
{
    public class BulkyDbContext : DbContext
    {
        public BulkyDbContext(DbContextOptions<BulkyDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
