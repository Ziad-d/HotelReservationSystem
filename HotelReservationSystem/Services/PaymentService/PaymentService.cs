using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.ViewModels.ReservationViewModels;
using Stripe;

namespace HotelReservationSystem.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public PaymentService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<ReservationToCreateDTO> CreateOrUpdatePaymentIntent(string paymentIntentId)
        {
            // Fetch the reservation from the database
            var reservation = _unitOfWork.GetRepo<Reservation>().Get(r => r.PaymentIntentId == paymentIntentId).FirstOrDefault();

            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found");
            }

            // Set up Stripe API key
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var service = new PaymentIntentService();

            // Declare paymentIntent variable
            PaymentIntent paymentIntent;

            if (string.IsNullOrEmpty(paymentIntentId))
            {
                // Create a new Payment Intent
                var options = new PaymentIntentCreateOptions
                {
                    Amount = CalculateReservationAmount(reservation), // Implement this to calculate total amount
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" },
                };
                paymentIntent = await service.CreateAsync(options);
                reservation.PaymentIntentId = paymentIntent.Id;
            }
            else
            {
                // Update existing Payment Intent
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = CalculateReservationAmount(reservation), // Implement this to calculate total amount
                };
                paymentIntent = await service.UpdateAsync(paymentIntentId, options);
                reservation.PaymentIntentId = paymentIntent.Id;
            }

            // Update the reservation in the database with the new PaymentIntentId
            _unitOfWork.GetRepo<Reservation>().Update(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();

            // Map the reservation to a DTO and return it
            var reservationToCreateDTO = reservation.MapOne<ReservationToCreateDTO>(); // Assuming a mapping method exists
            return reservationToCreateDTO;
        }


        public async Task<ReservationToReturnViewModel> UpdateReservationPaymentSucceeded(string paymentIntentId)
        {
            // Fetch the reservation from the database
            var reservation = _unitOfWork.GetRepo<Reservation>().Get(r => r.PaymentIntentId == paymentIntentId).FirstOrDefault();

            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found");
            }

            // Update the reservation status
            reservation.IsCanceled = false; // Assuming a non-canceled status indicates a confirmed reservation
            _unitOfWork.GetRepo<Reservation>().Update(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();

            // Map to ViewModel
            var reservationToReturnViewModel = reservation.MapOne<ReservationToReturnViewModel>(); // Assuming a mapping method exists
            return reservationToReturnViewModel;
        }

        public async Task<ReservationToReturnViewModel> UpdateReservationPaymentFailed(string paymentIntentId)
        {
            // Fetch the reservation from the database
            var reservation = _unitOfWork.GetRepo<Reservation>().Get(r => r.PaymentIntentId == paymentIntentId).FirstOrDefault();

            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found");
            }

            // Update the reservation to indicate payment failure
            reservation.IsCanceled = true; // You might have a different logic for payment failures
            _unitOfWork.GetRepo<Reservation>().Update(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();

            // Map to ViewModel
            var reservationToReturnViewModel = reservation.MapOne<ReservationToReturnViewModel>(); // Assuming a mapping method exists
            return reservationToReturnViewModel;
        }

        private long CalculateReservationAmount(Reservation reservation)
        {
            // Assuming each room has a property PricePerNight of type decimal
            decimal totalAmount = 0;

            foreach (var room in reservation.Rooms)
            {
                totalAmount += room.Price * reservation.NumberOfReservedDays;
            }

            // Stripe expects amount in cents
            return (long)(totalAmount * 100);
        }
    }
}
