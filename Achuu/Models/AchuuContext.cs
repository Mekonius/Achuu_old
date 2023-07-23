//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Achuu.Models
{
    public class AchuuContext : DbContext
    {
        
        public DbSet<User>? Users { get; set; } 
        public DbSet<Locker>? Lockers { get; set; } 
        public DbSet<Product>? Products { get; set; } 
        public DbSet<Ingredient>? Ingredients { get; set; }
        public DbSet<ProductColor>? ProductColors { get; set; }

        public string DbPath { get; } 

        public AchuuContext(DbContextOptions<AchuuContext> options) : base(options)
        {
            DbPath = "Achuu.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

  
}
