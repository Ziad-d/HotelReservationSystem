using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Mediators.ReservationMediators;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationMediator _reservationMediator;

        public ReservationController(IReservationService reservationService, IReservationMediator reservationMediator)
        {
            _reservationService = reservationService;
            _reservationMediator = reservationMediator;
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> CreateReservation(ReservationToCreateViewModel viewModel)
        {
            var reservation = viewModel.MapOne<ReservationToCreateDTO>();
            await _reservationMediator.Add(reservation);
            return ResponseViewModel<bool>.Sucess(true, "Reservation has been Created");
        }

        [HttpGet]
        public ResponseViewModel<IEnumerable<ReservationToReturnViewModel>> GetAllReservations()
        {
            var reservations = _reservationService.GetAllReservations();
            var mappedReservations = reservations.Select(x => x.MapOne<ReservationToReturnViewModel>());
            return ResponseViewModel<IEnumerable<ReservationToReturnViewModel>>.Sucess(mappedReservations, "Reservations have been retrieved");
        }

        [HttpGet("{id}")]
        public ResponseViewModel<ReservationToReturnViewModel> GetSingleReservation(int id)
        {
            var reservation = _reservationService.GetSingleReservation(id);
            var mappedReservation = reservation.MapOne<ReservationToReturnViewModel>();
            return ResponseViewModel<ReservationToReturnViewModel>.Sucess(mappedReservation, $"Reservation with ID: '{id}' has been retrieved");
        }

        [HttpPatch("{id}")]
        public ResponseViewModel<bool> CancelReservation(int id)
        {
            _reservationService.CancelReservation(id);
            return ResponseViewModel<bool>.Sucess(true, "Reservation Cancelled");
        }
    }
}
