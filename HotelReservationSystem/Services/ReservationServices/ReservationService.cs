using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
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
        
        public void Add(ReservationToCreateDTO reservationDTO)
        {
            var reservation = reservationDTO.MapOne<Reservation>();
            _unitOfWork.GetRepo<Reservation>().Add(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();
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

        public void CancelReservation(int id)
        {
            var reservation = _unitOfWork.GetRepo<Reservation>().GetByIDWithTracking(id);
            reservation.IsCanceled = true;
            _unitOfWork.GetRepo<Reservation>().SaveChanges();
        }
    }
}
