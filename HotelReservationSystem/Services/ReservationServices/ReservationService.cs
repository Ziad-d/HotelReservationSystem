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

        public int GetReservationCount(ReservationFilterDTO filter)
        {
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();

            var query = reservationRepo.GetAll();

            if (filter.CheckInDate.HasValue)
            {
                query = query.Where(r => r.CheckInDate >= filter.CheckInDate.Value);
            }

            if (filter.CheckOutDate.HasValue)
            {
                query = query.Where(r => r.CheckOutDate <= filter.CheckOutDate.Value);
            }

            if (filter.ReservationStatus.HasValue)
            {
                query = query.Where(r => r.ReservationStatus == filter.ReservationStatus.Value);
            }

            return query.Count();
        }


        public IEnumerable<ReservationToReturnDTO> GetAll()
        {
            var reservations = _unitOfWork.GetRepo<Reservation>().GetAll();
            return reservations.Map<ReservationToReturnDTO>();
        }

        public ReservationToReturnDTO GetById(int id)
        {
            var reservation = _unitOfWork.GetRepo<Reservation>()
                .GetByID(id)
                .Map<ReservationToReturnDTO>()
                .FirstOrDefault();
            return reservation;
        }

        //public void CancelReservation(int id)
        //{
        //    var reservation = _unitOfWork.GetRepo<Reservation>().GetByIDWithTracking(id);
        //    reservation.IsCanceled = true;
        //    _unitOfWork.GetRepo<Reservation>().SaveChanges();
        //}
    }
}
