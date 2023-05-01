using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.User.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.User> Users { get; set; }
    }
}
