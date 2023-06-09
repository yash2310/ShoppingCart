﻿using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Payment.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Domain.Entities.Payment> Payments { get; set; }
    }
}
