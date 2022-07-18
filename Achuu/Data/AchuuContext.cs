using Microsoft.EntityFrameworkCore;

namespace Achuu.Data
{
    public class AchuuContext : DbContext
    {
        
        public DbSet<User>? Users { get; set; } 
        public DbSet<Locker>? Lockers { get; set; } 
        public DbSet<Product>? Products { get; set; } 
        public DbSet<Ingredient>? Ingredients { get; set; }

        public string DbPath { get;  }

        public AchuuContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, "Achuu.db");
        }
        
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }

  
}
