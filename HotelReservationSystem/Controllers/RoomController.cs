using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost]
        public bool Create(RoomToCreateViewModel viewModel)
        {
            var room = viewModel.MapOne<RoomToCreateDTO>();
            roomService.Add(room);
            return true;
        }

        [HttpPut]
        public IActionResult Update(int id, RoomToUpdateViewModel viewModel)
        {
            if (id != viewModel.ID)
            {
                return BadRequest("Room ID mismatch");
            }

            var roomDTO = viewModel.MapOne<RoomToUpdateDTO>();
            roomService.Update(roomDTO);

            return Ok();
        }
    }
}
