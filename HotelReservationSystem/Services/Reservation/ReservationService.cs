using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Services.Rooms
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public void Update(int id, RoomToUpdateDTO roomDTO)
        //{
        //    //var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Room not found");

        //    //room.Price = roomDTO.Price;
        //    //room.PictureUrl = roomDTO.PictureUrl;
        //    //room.IsAvailable = roomDTO.IsAvailable;
        //    //room.Description = roomDTO.Description;
        //    //room.RoomType = roomDTO.RoomType;
        //    //room.Facilities = roomDTO.Facilities;

        //    //_repository.Update(room);
        //    //roomDTO.MapOne(room);
        //    //_unitOfWork.GetRepo<Room>().SaveChanges();        //}

        //}
        public void  CancelReservation(int id , ReservationToUpdateDTO reservationToUpdateDTO)
        {
            var reservation = _unitOfWork.GetRepo<Reservation>().GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Reservation not found");


            reservationToUpdateDTO.MapOne(reservation);

            _unitOfWork.GetRepo<Reservation>().SaveChanges();        //}

        }
        public void Add(ReservationToCreateDTO reservationDTO)
        {
            var reservation = reservationDTO.MapOne<Reservation>();
            _unitOfWork.GetRepo<Reservation>().Add(reservation);
            _unitOfWork.GetRepo<Reservation>().SaveChanges();
        }
        public IEnumerable<ReservationToReturnDTO> GetReservations()
        {
            var reservations = _unitOfWork.GetRepo<Reservation>().GetAll();
            return reservations.Map<ReservationToReturnDTO>();
        }


        //public Reservation GetReservationById(int id)
        //{
        //    var reservation = _unitOfWork.GetRepo<Reservation>().GetByIDWithTracking(id);
        //    return 
        //}
        //public RoomToReturnDTO GetRoomById(int id)
        //{
        //    var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id);
        //}
        //public void Add(RoomToCreateDTO roomDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<RoomToReturnDTO> GetAvailableRooms()
        //{
        //    throw new NotImplementedException();
        //}

        //public RoomToReturnDTO GetRoomById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<RoomToReturnDTO> GetRooms()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
