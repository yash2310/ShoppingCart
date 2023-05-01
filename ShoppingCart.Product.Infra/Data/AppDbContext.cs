using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Product.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.Product> Products { get; set; }
    }
}
