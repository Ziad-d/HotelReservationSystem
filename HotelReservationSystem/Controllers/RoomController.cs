using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Room;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public IEnumerable<RoomToReturnViewModel> GetAllRooms()
        {
            var rooms = roomService.GetRooms();
            return rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
        }

        [HttpGet("{id}")]
        public RoomToReturnViewModel GetRoomById(int id)
        {
            var room = roomService.GetRoomById(id);
            return room.MapOne<RoomToReturnViewModel>();
        }

        [HttpGet]
        public IEnumerable<RoomToReturnViewModel> GetAvailableRooms()
        {
            var rooms = roomService.GetAvailableRooms();
            return rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
        }

        [HttpPost]
        public bool CreateRoom(RoomToCreateViewModel viewModel)
        {
            var room = viewModel.MapOne<RoomToCreateDTO>();
            roomService.Add(room);
            return true;
        }

        [HttpPut]
        public bool UpdateRoom(int id, RoomToUpdateViewModel viewModel)
        {
            var roomDTO = viewModel.MapOne<RoomToUpdateDTO>();
            roomService.Update(id, roomDTO);
            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            roomService.Delete(id);
            return true;
        }
    }
}
