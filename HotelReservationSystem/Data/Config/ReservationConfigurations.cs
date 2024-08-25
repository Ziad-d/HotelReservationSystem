using HotelReservationSystem.Models.Reservations;
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
        }
    }
}
