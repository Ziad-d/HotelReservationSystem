using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
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

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
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

        [HttpGet]
        public ResponseViewModel<IEnumerable<RoomToReturnViewModel>> GetAvailableRooms()
        {
            var rooms = _roomService.GetAvailableRooms();
            var mappedRooms = rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
            return ResponseViewModel<IEnumerable<RoomToReturnViewModel>>.Sucess(mappedRooms);
        }

        [HttpPost]
        public ResponseViewModel<bool> CreateRoom(RoomToCreateViewModel viewModel)
        {
            var room = viewModel.MapOne<RoomToCreateDTO>();
            _roomService.Add(room);
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
