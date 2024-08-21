
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Room;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _repository;

        public FacilityService(IRepository<Facility> repository)
        {
            _repository = repository;
        }
        
        public void Add(FacilityToCreateDTO facilityDTO)
        {
            var facility = facilityDTO.MapOne<Facility>();
            _repository.Add(facility);
            _repository.SaveChanges();
        }

        public IEnumerable<FacilityToReturnDTO> GetAllFacilities()
        {
            var facilities = _repository.GetAll();
            return facilities.Map<FacilityToReturnDTO>();
        }

        public FacilityToReturnDTO GetFacilityById(int id)
        {
            var facility = _repository.GetByIDWithTracking(id);
            return facility.MapOne<FacilityToReturnDTO>();
        }

        public void Update(int id, FacilityToUpdateDTO facilityDTO)
        {
            var facility = _repository.GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Facility not found");
            facilityDTO.MapOne(facility);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var facility = _repository.GetByIDWithTracking(id);
            _repository.Delete(facility);
            _repository.SaveChanges();
        }
    }
    
}
