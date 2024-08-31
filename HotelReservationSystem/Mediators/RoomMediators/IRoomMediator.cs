using HotelReservationSystem.DTOs.RoomDTOs;

namespace HotelReservationSystem.Mediators.RoomMediators
{
    public interface IRoomMediator
    {
        Task<RoomToReturnDTO> Add(RoomToCreateDTO roomDTO);
    }
}