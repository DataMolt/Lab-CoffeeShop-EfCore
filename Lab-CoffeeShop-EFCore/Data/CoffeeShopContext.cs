using Lab_CoffeeShop_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_CoffeeShop_EFCore.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(_ => _.ProductId);

                p.HasData(
                 new Product() { ProductId = 1, Name = "Black Coffee", Description = "Some damn fine coffee", Price = 2 },
                 new Product() { ProductId = 2, Name = "Pour Over", Description = "Takes forever", Price = 4 },
                 new Product() { ProductId = 3, Name = "Iced Coffee", Description = "Frozen, chewable", Price = 3 },
                 new Product() { ProductId = 4, Name = "Espresso", Description = "Smaller cup, larger price", Price = 4 }
                 );
            });
        }
    }
}
