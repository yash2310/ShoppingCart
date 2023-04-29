using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Payment.Infra.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }

        public DbSet<Domain.Entities.Payment> Payments { get; set; }
    }
}
