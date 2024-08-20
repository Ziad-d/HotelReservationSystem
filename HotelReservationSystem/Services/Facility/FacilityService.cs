
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
        
        public void Add(FacilityToCreateDTO facilityDTO)
        {
            var facility = facilityDTO.MapOne<Facility>();
            repository.Add(facility);
            repository.SaveChanges();
        }

        public IEnumerable<FacilityToReturnDTO> GetAllFacilities()
        {
            var facilities = repository.GetAll();
            return facilities.Map<FacilityToReturnDTO>();
        }

        public FacilityToReturnDTO GetFacilityById(int id)
        {
            var facility = repository.GetByIDWithTracking(id);
            return facility.MapOne<FacilityToReturnDTO>();
        }

        public void Update(int id, FacilityToUpdateDTO facilityDTO)
        {
            var facility = repository.GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Facility not found");
            facilityDTO.MapOne(facility);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var facility = repository.GetByIDWithTracking(id);
            repository.Delete(facility);
            repository.SaveChanges();
        }
    }
    
}
