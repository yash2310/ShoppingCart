using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Cart.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.Cart> Carts { get; set; }
        public DbSet<Domain.Entities.CartProduct> CartProducts { get; set; }
    }
}
