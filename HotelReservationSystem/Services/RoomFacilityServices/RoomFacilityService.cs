using ExaminationSystem.Helpers;
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
            var roomFacility = _unitOfWork.GetRepo<RoomFacility>();
            var facilitiesToAdd = _unitOfWork.GetRepo<Facility>()
                .Get(f => facilityIDs.Contains(f.ID) && 
                !roomFacility.GetAll()
                .Any(rf => rf.RoomId == roomID && rf.FacilityId == f.ID && rf.IsDeleted == false));
            
            if(!facilityIDs.Any())
            {
                return;
            }

            var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(roomID);
            // if room == null
            foreach(var facility in facilitiesToAdd)
            {
                room.RoomFacilities.Add(new RoomFacility
                {
                    RoomId = room.ID,
                    FacilityId = facility.ID,
                });
            }

            _unitOfWork.GetRepo<Room>().Update(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
        }
    }
}
