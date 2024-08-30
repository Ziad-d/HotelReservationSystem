using ExaminationSystem.Helpers;
using HotelReservationSystem.Services.PaymentService;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult<ReservationToCreateViewModel>> CreateOrUpdatePaymentIntent(string paymentIntentId)
        {
            if (string.IsNullOrEmpty(paymentIntentId))
            {
                return BadRequest("PaymentIntentId is required.");
            }

            var reservationDto = await _paymentService.CreateOrUpdatePaymentIntent(paymentIntentId);

            if (reservationDto == null)
            {
                return NotFound("Reservation could not be found or updated.");
            }

            var viewModel = reservationDto.MapOne<ReservationToCreateViewModel>();
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationToReturnViewModel>> PaymentSucceeded(string paymentIntentId)
        {
            if (string.IsNullOrEmpty(paymentIntentId))
            {
                return BadRequest("PaymentIntentId is required.");
            }

            var reservationViewModel = await _paymentService.UpdateReservationPaymentSucceeded(paymentIntentId);

            if (reservationViewModel == null)
            {
                return NotFound("Reservation could not be updated as payment succeeded.");
            }

            return Ok(reservationViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationToReturnViewModel>> PaymentFailed(string paymentIntentId)
        {
            if (string.IsNullOrEmpty(paymentIntentId))
            {
                return BadRequest("PaymentIntentId is required.");
            }

            var reservationViewModel = await _paymentService.UpdateReservationPaymentFailed(paymentIntentId);

            if (reservationViewModel == null)
            {
                return NotFound("Reservation could not be updated as payment failed.");
            }

            return Ok(reservationViewModel);
        }
    }
}
