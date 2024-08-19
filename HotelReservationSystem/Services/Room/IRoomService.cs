using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        void Add(RoomToCreateDTO roomDTO);
        void Update(RoomToUpdateDTO roomDTO);
    }
}
