using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace HotelReservationSystem.Data
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HotelReservationSystem;TrustServerCertificate=true")
            //optionsBuilder.UseSqlServer("Server=.;Database=HotelReservation;User Id=sa;Password=123;Encrypt=False;;TrustServerCertificate=true")
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        //    modelBuilder.Entity<Feedback>()
        //        .Property(p => p.Rating)
        //        .HasDefaultValue(1)
        //        .IsRequired();
               
        //    ApplyRatingRangeConstraints(modelBuilder);
        //
        }

        //private void ApplyRatingRangeConstraints(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Feedback>()
        //        .HasCheckConstraint("CK_Rating", "Rating BETWEEN 1 AND 5");
                
        //}
    }
}
