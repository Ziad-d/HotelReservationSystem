using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.ViewModels.ReservationViewModels;
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
    }
}
