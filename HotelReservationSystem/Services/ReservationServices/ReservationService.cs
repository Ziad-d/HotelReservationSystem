using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Models.Rooms;
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
            var reservation = MapperHelper.MapOne<Reservation>(reservationDTO);
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
            var reservation = _unitOfWork.GetRepo<Reservation>().GetByIDWithTracking(id);
            return reservation.MapOne<ReservationToReturnDTO>();
        }
    }
}
