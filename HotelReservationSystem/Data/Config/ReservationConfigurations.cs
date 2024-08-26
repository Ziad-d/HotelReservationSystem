using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservationSystem.Data.Config
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasMany(r => r.Rooms)
                .WithOne(room => room.Reservation);
            builder.HasCheckConstraint("CK_Reservation_CheckDates", "[CheckOutDate] > [CheckInDate]");
            builder.Property(r => r.TotalPrice)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
