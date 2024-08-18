using HotelReservationSystem.Models.Room;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace HotelReservationSystem.Data
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelReservationSystem;TrustServerCertificate=true")
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
