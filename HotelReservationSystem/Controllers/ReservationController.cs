using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IEnumerable<ReservationToReturnViewModel> GetAllReservations()
        {
            var reservations = _reservationService.GetReservations();
            return reservations.Select(x => x.MapOne<ReservationToReturnViewModel>());
        }

        //[HttpGet("{id}")]
        //public RoomToReturnViewModel GetRoomById(int id)
        //{
        //    var room = _roomService.GetRoomById(id);
        //    return room.MapOne<RoomToReturnViewModel>();
        //}

        //[HttpGet]
        //public IEnumerable<RoomToReturnViewModel> GetAvailableRooms()
        //{
        //    var rooms = _roomService.GetAvailableRooms();
        //    return rooms.Select(x => x.MapOne<RoomToReturnViewModel>());
        //}

        [HttpPost]
        public bool CreateReservation(ReservationToCreateViewModel viewModel)
        {
            var reservation = viewModel.MapOne<ReservationToCreateDTO>();
            _reservationService.Add(reservation);
            return true;
        }

        [HttpPut]
        public bool Cancel(int id , ReservationToUpdateViewModel viewModel)
        {
            var reservationDTO = viewModel.MapOne<ReservationToUpdateDTO>();
            _reservationService.CancelReservation(id ,reservationDTO);

            return true;
        }
    }
}
