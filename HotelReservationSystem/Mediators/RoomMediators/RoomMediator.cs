using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Services.RoomFacilityServices;
using HotelReservationSystem.Services.RoomServices;

namespace HotelReservationSystem.Mediators.RoomMediators
{
    public class RoomMediator : IRoomMediator
    {
        private readonly IRoomService _roomService;
        private readonly IRoomFacilityService _roomFacilityService;

        public RoomMediator(IRoomService roomService, IRoomFacilityService roomFacilityService)
        {
            _roomService = roomService;
            _roomFacilityService = roomFacilityService;
        }

        public async Task<RoomToReturnDTO> Add(RoomToCreateDTO roomDTO)
        {
            var roomToAdd = await _roomService.AddAsync(roomDTO);
            _roomFacilityService.AddFacilitiesToRoom(roomToAdd.ID, roomDTO.FacilityIDs);
            var mappedRoom = roomToAdd.MapOne<RoomToReturnDTO>();

            return mappedRoom;
        }
    }
}
