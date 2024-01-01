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

        private readonly ILogger<AchuuContext> _logger;


        public AchuuContext(DbContextOptions<AchuuContext> options, ILogger<AchuuContext> logger) : base(options)
        {
            DbPath = "Achuu.db";
            _logger = logger;
            _logger.LogInformation(" ======================= DbContext created. ========================== ");
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Name)
            .IsUnique();

    }

        public override void Dispose()
        {
            base.Dispose();
            _logger.LogInformation("DbContext disposed.");
        }
    }
}
