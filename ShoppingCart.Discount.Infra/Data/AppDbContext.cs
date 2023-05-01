using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Discount.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.Discount> Discounts { get; set; }
    }
}
