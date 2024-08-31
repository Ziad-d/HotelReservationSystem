using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoomServices
{
    public interface IRoomService
    {
        Task<Room> AddAsync(RoomToCreateDTO roomDTO);
        void Update(int id, RoomToUpdateDTO roomDTO);
        IEnumerable<RoomToReturnDTO> GetRooms();
        RoomToReturnDTO GetRoomById(int id);
        void Delete(int id);
    }
}
