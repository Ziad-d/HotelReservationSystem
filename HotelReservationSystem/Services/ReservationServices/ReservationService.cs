using ExaminationSystem.Exceptions;
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
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            if (!reservationRepo.ValidateInputDate(reservationDTO.CheckInDate, reservationDTO.CheckOutDate))
            {
                throw new BusinessException(ErrorCode.NotValidDates, "Invalid check-in or check-out date");
            }
            var reservation = reservationDTO.MapOne<Reservation>();
            await reservationRepo.AddAsync(reservation);
            reservation.ReservationStatus = ReservationStatus.Pending;
            reservationRepo.SaveChanges();
            return reservation;
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
                throw new BusinessException(ErrorCode.ReservationNotFound, "Reservation not found");
            }
            var mappedReservation = reservation.Map<ReservationToReturnDTO>().FirstOrDefault();
            return mappedReservation;
        }

        public bool CancelReservation(int reservationId)
        {
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            var reservation = reservationRepo.GetByIDWithTracking(reservationId);

            ValidateReservationForCancellation(reservation);

            reservation.ReservationStatus = ReservationStatus.Cancelled;

            reservationRepo.Update(reservation);
            reservationRepo.SaveChanges();

            return true;
        }

        private void ValidateReservationForCancellation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new BusinessException(ErrorCode.ReservationNotFound, "Reservation not found");
            }

            if (reservation.ReservationStatus == ReservationStatus.Cancelled)
            {
                throw new BusinessException(ErrorCode.ReservationWasCancelled, "Reservation was already cancelled");
            }
        }
    }
}
