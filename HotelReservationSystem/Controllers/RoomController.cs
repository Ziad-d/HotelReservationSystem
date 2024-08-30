using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Mediators;
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
        private readonly IRoomMediator _roomMediator;

        public RoomController(IRoomService roomService, IRoomMediator roomMediator)
        {
            _roomService = roomService;
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
            var Addedroom = _roomService.AddAsync(room);
            return ResponseViewModel<bool>.Sucess(true);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> CreateRoomWithFacilities(RoomToCreateViewModel viewModel)
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
