
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Room;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> repository;

        public FacilityService(IRepository<Facility> repository)
        {
            this.repository = repository;
        }
        
        public void Add(FacilityDto facilityDto)
        {
            var facility = facilityDto.MapOne<Facility>();
            repository.Add(facility);
            repository.SaveChanges();
        }

        public IEnumerable<FacilityDto> GetAllFacilities()
        {
            var facilities = repository.GetAll();
            return facilities.Map<FacilityDto>();
        }

        public FacilityDto GetFacilityById(int id)
        {
            var facility = repository.GetByIDWithTracking(id);
            return facility.MapOne<FacilityDto>();
        }
    }
    
}
