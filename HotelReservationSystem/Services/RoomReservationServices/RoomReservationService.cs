﻿using ExaminationSystem.Exceptions;
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Helpers;
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
                throw new BusinessException(ErrorCode.ReservationNotFound, "Reservation not found");
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

        public IEnumerable<RoomToReturnDTO> GetReservedRoomsByReservationId(int reservationId)
        {
            if (reservationId <= 0)
            {
                throw new BusinessException(ErrorCode.NotValidReservationID, "Invalid reservation ID");
            }
            var roomReservationRepo = _unitOfWork.GetRepo<RoomReservation>();
            var roomRepo = _unitOfWork.GetRepo<Room>();

            var roomReservations = roomReservationRepo.Get(rr =>  rr.ReservationId == reservationId && !rr.IsDeleted);

            if (!roomReservations.Any())
            {
                throw new BusinessException(ErrorCode.RoomNotFound, "No rooms found for the given reservation ID.");
            }

            var roomIds = roomReservations.Select(rr => rr.RoomId).ToList();

            var rooms = roomRepo.Get(r => roomIds.Contains(r.ID));

            return rooms.Select(x => x.MapOne<RoomToReturnDTO>());
        }

        public IEnumerable<RoomToReturnDTO> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var roomRepo = _unitOfWork.GetRepo<Room>();
            var reservationRepo = _unitOfWork.GetRepo<Reservation>();
            var roomReservationRepo = _unitOfWork.GetRepo<RoomReservation>();

            if (ValidateDates.ValidateInputDate(checkInDate, checkOutDate))
            {
                throw new BusinessException(ErrorCode.NotValidDates, "Invalid check-in or check-out date");
            }

            var allRooms = roomRepo.GetAll();

            var overlappingReservations = roomReservationRepo.Get(rr =>
                (rr.Reservation.CheckInDate < checkOutDate && rr.Reservation.CheckOutDate > checkInDate) &&
                !rr.IsDeleted
            ).ToList();

            var reservedRoomIds = overlappingReservations.Select(rr => rr.RoomId).ToHashSet();

            var availableRooms = allRooms.Where(room => !reservedRoomIds.Contains(room.ID)).ToList();

            return availableRooms.Select(x => x.MapOne<RoomToReturnDTO>());
        }
    }
}
