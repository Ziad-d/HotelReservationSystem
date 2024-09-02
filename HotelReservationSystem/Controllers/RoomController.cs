using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Mediators.RoomMediators;
using HotelReservationSystem.Services.RoomReservationServices;
using HotelReservationSystem.Services.RoomServices;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.RoomViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IRoomReservationService _roomReservationService;
        private readonly IRoomMediator _roomMediator;

        public RoomController(IRoomService roomService,IRoomReservationService roomReservationService, IRoomMediator roomMediator)
        {
            _roomService = roomService;
            _roomReservationService = roomReservationService;
            _roomMediator = roomMediator;
        }

        [HttpGet]
        public ResponseViewModel<IEnumerable<RoomToReturnViewModel>> GetAllRooms()
        {
            var rooms = _roomService.GetRooms();
            var mappedRooms = rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
            return ResponseViewModel<IEnumerable<RoomToReturnViewModel>>.Sucess(mappedRooms);
        }

        [HttpGet("{id}")]
        public ResponseViewModel<RoomToReturnViewModel> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);
            var mappedRoom = room.MapOne<RoomToReturnViewModel>();
            return ResponseViewModel<RoomToReturnViewModel>.Sucess(mappedRoom);
        }

        [HttpGet("{reservationId}")]
        public ResponseViewModel<IEnumerable<RoomToReturnViewModel>> GetReservedRoomsByReservationId(int reservationId)
        {
            var rooms = _roomReservationService.GetReservedRoomsByReservationId(reservationId);
            var mappedRooms = rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
            return ResponseViewModel<IEnumerable<RoomToReturnViewModel>>.Sucess(mappedRooms, $"Rooms with reservation ID: '{reservationId}' have been retrieved");
        }

        [HttpGet]
        public ResponseViewModel<IEnumerable<RoomToReturnViewModel>> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var rooms = _roomReservationService.GetAvailableRooms(checkInDate, checkOutDate);
            var mappedRooms = rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
            return ResponseViewModel<IEnumerable<RoomToReturnViewModel>>.Sucess(mappedRooms, "Available rooms have been retrieved");
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> CreateRoom(RoomToCreateViewModel viewModel)
        {
            var room = viewModel.MapOne<RoomToCreateDTO>();
            await _roomMediator.Add(room);
            return ResponseViewModel<bool>.Sucess(true);
        }

        [HttpPut("{id}")]
        public ResponseViewModel<bool> UpdateRoom(int id, RoomToUpdateViewModel viewModel)
        {
            var roomDTO = viewModel.MapOne<RoomToUpdateDTO>();
            _roomService.Update(id, roomDTO);
            return ResponseViewModel<bool>.Sucess(true);
        }
    }
}
