﻿using ExaminationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.RoomFacilityServices
{
    public class RoomFacilityService : IRoomFacilityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomFacilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFacilitiesToRoom(int roomID, HashSet<int> facilityIDs)
        {
            var roomFacilityRepo = _unitOfWork.GetRepo<RoomFacility>();
            var roomRepo = _unitOfWork.GetRepo<Room>();

            var facilitiesToAdd = _unitOfWork.GetRepo<Facility>()
                .Get(f => facilityIDs.Contains(f.ID) && 
                !roomFacilityRepo.GetAll()
                .Any(rf => rf.RoomId == roomID && rf.FacilityId == f.ID && rf.IsDeleted == false));
            
            if(!facilityIDs.Any())
            {
                return;
            }

            var room = roomRepo.GetByIDWithTracking(roomID);

            if (room == null)
            {
                throw new Exception("Room not found");
            }

            if (room.RoomFacilities == null)
            {
                room.RoomFacilities = new HashSet<RoomFacility>();
            }

            foreach(var facility in facilitiesToAdd)
            {
                room.RoomFacilities.Add(new RoomFacility
                {
                    RoomId = room.ID,
                    FacilityId = facility.ID,
                });
            }

            roomRepo.Update(room);
            roomRepo.SaveChanges();
        }
    }
}
