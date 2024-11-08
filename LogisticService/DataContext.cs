using LogisticService.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticService
{
    public class DataContext : DbContext
    {
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Crashed> Crasheds { get; set; }
        public DbSet<Containers> Containers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LogisticService2Db;Integrated Security=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(u => u.Users)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.Id);
        }
    }
}
