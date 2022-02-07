using Microsoft.EntityFrameworkCore;
using TSI.Models;

namespace TSI.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CarsOrdersConnector> CarsOrdersConnectors { get; set;}

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tsi;Username=postgres;Password=fedogo16");
        }
    }

}
