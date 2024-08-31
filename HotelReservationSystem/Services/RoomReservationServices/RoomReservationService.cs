using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.RoomReservationServices
{
    public class RoomReservationService : IRoomReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ReserveRooms(int reservationID, List<int> roomsNumber)
        {
            var roomReservationRepo = _unitOfWork.GetRepo<RoomReservation>();
            var roomRepo = _unitOfWork.GetRepo<Room>();
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();

            var reservation = reservationRepo.GetByIDWithTracking(reservationID);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            var roomsToAdd = roomRepo.Get(r => roomsNumber.Contains(r.RoomNumber) &&
                !roomReservationRepo.GetAll()
                .Any(rr => rr.ReservationId == reservationID && rr.RoomId == r.ID && rr.IsDeleted == false));

            if (!roomsNumber.Any())
            {
                return;
            }

            if (reservation.RoomReservations == null)
            {
                reservation.RoomReservations = new List<RoomReservation>();
            }

            foreach (var room in roomsToAdd)
            {
                reservation.RoomReservations.Add(new RoomReservation
                {
                    RoomId = room.ID,
                    ReservationId = reservation.ID,
                });
            }

            reservationRepo.Update(reservation);
            reservationRepo.SaveChanges();
        }

    }
}
