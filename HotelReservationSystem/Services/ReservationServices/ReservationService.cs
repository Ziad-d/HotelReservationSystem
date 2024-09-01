using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> AddAsync(ReservationToCreateDTO reservationDTO)
        {
            if (!ValidateInputDate(reservationDTO.CheckInDate, reservationDTO.CheckOutDate))
            {
                throw new Exception("Invalid check-in or check-out date");
            }
            var reservation = reservationDTO.MapOne<Reservation>();
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            await reservationRepo.AddAsync(reservation);
            reservation.ReservationStatus = ReservationStatus.Pending;
            reservationRepo.SaveChanges();
            return reservation;
        }

        private bool ValidateInputDate(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn < DateTime.UtcNow || checkOut < DateTime.UtcNow)
            {
                return false;
            }

            if (checkOut <= checkIn)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<ReservationToReturnDTO> GetAllReservations()
        {
            var reservations = _unitOfWork.GetRepo<Reservation>().GetAll();
            return reservations.Map<ReservationToReturnDTO>();
        }

        public ReservationToReturnDTO GetSingleReservation(int id)
        {
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            var reservation = reservationRepo.GetByID(id);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }
            var mappedReservation = reservation.Map<ReservationToReturnDTO>().FirstOrDefault();
            return mappedReservation;
        }

        public bool CancelReservation(int reservationId)
        {
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            var reservation = reservationRepo.GetByIDWithTracking(reservationId);

            if (reservation == null)
            {
                return false;
            }

            if (reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                return false;
            }

            reservation.ReservationStatus = ReservationStatus.Cancelled;

            reservationRepo.Update(reservation);
            reservationRepo.SaveChanges();

            return true;
        }
    }
}
