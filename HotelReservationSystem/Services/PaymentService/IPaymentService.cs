using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.ViewModels.ReservationViewModels;
namespace HotelReservationSystem.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ReservationToCreateDTO> CreateOrUpdatePaymentIntent(string paymentIntent);

        Task<ReservationToReturnViewModel> UpdateReservationPaymentSucceeded(string paymentIntent);

        Task<ReservationToReturnViewModel> UpdateReservationPaymentFailed(string paymentIntent);

    }
}
