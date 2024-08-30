using HotelReservationSystem.DTOs.RoomDTOs;

namespace HotelReservationSystem.Mediators
{
    public interface IRoomMediator
    {
        Task<RoomToReturnDTO> Add(RoomToCreateDTO roomDTO);
    }
}