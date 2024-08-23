using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Reservations;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IReservationService
    {
        //Reservation GetReservationById(int id);
        void CancelReservation(int id ,ReservationToUpdateDTO reservationToUpdateDTO);
        void Add(ReservationToCreateDTO reservationToCreateDTO);
        IEnumerable<ReservationToReturnDTO> GetReservations();
        //void Update(int id, ReservationToUpdateDTO reservationToUpdateDTO);
        //IEnumerable<RoomToReturnDTO> GetAvailableRooms();
        //RoomToReturnDTO GetRoomById(int id);
        //void Delete(int id);
    }
}
