using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Mediators.ReservationMediator;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.ViewModels;
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
        private readonly IReservationMediator _reservationMediator;

        public ReservationController(IReservationService reservationService, IReservationMediator reservationMediator)
        {
            _reservationService = reservationService;
            _reservationMediator = reservationMediator;
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> CreateReservationWithRooms(ReservationToCreateViewModel viewModel)
        {
            var reservation = viewModel.MapOne<ReservationToCreateDTO>();
            await _reservationMediator.Add(reservation);
            return ResponseViewModel<bool>.Sucess(true);
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

        //[HttpPatch]
        //public bool CancelReservation(int id)
        //{
        //    _reservationService.CancelReservation(id);
        //    return true;
        //}
    }
}
