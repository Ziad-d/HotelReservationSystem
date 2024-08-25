using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using HotelReservationSystem.ViewModels.RoomViewModels;
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

        [HttpPost]
        public bool CreateReservation(ReservationToCreateViewModel viewModel)
        {
            var reservation = viewModel.MapOne<ReservationToCreateDTO>();
            _reservationService.Add(reservation);
            return true;
        }

        [HttpGet]
        public IEnumerable<ReservationToReturnViewModel> GetAllReservation()
        {
            var reservations = _reservationService.GetAll();
            return reservations.Select(x => x.MapOne<ReservationToReturnViewModel>());
        }

        [HttpGet("{id}")]
        public ReservationToReturnViewModel GetReservationById(int id)
        {
            var reservation = _reservationService.GetById(id);
            return reservation.MapOne<ReservationToReturnViewModel>();
        }
    }
}
