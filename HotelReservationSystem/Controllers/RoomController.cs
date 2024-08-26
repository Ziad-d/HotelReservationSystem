using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Services.RoomServices;
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
        public IEnumerable<RoomToReturnViewModel> GetAllRooms()
        {
            var rooms = _roomService.GetRooms();
            return rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
        }

        [HttpGet("{id}")]
        public RoomToReturnViewModel GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);
            return room.MapOne<RoomToReturnViewModel>();
        }

        [HttpGet]
        public IEnumerable<RoomToReturnViewModel> GetAvailableRooms()
        {
            var rooms = _roomService.GetAvailableRooms();
            return rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
        }

        [HttpPost]
        public bool CreateRoom(RoomToCreateViewModel viewModel)
        {
            var room = viewModel.MapOne<RoomToCreateDTO>();
            _roomService.Add(room);
            return true;
        }

        [HttpPut("{id}")]
        public bool Update(int id, RoomToUpdateViewModel viewModel)
        {
            var roomDTO = viewModel.MapOne<RoomToUpdateDTO>();
            _roomService.Update(id, roomDTO);

            return true;
        }
    }
}
