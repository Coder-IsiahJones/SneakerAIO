using Microsoft.EntityFrameworkCore;

namespace SneakerAIO.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SneakerModel> Sneaker { get; set; }
    }
}