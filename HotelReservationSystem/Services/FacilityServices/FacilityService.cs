using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.FacilityDTOs;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.FacilityServices
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Add(FacilityToCreateDTO facilityDTO)
        {
            var facility = facilityDTO.MapOne<Facility>();
            _unitOfWork.GetRepo<Facility>().Add(facility);
            _unitOfWork.GetRepo<Facility>().SaveChanges();
        }

        public IEnumerable<FacilityToReturnDTO> GetAllFacilities()
        {
            var facilities = _unitOfWork.GetRepo<Facility>().GetAll();
            return facilities.Map<FacilityToReturnDTO>();
        }

        public FacilityToReturnDTO GetFacilityById(int id)
        {
            var facility = _unitOfWork.GetRepo<Facility>().GetByIDWithTracking(id);
            return facility.MapOne<FacilityToReturnDTO>();
        }

        public void Update(int id, FacilityToUpdateDTO facilityDTO)
        {
            var facility = _unitOfWork.GetRepo<Facility>().GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Facility not found");
            facilityDTO.MapOne(facility);
            _unitOfWork.GetRepo<Facility>().SaveChanges();
        }

        public void Delete(int id)
        {
            var facility = _unitOfWork.GetRepo<Facility>().GetByIDWithTracking(id);
            _unitOfWork.GetRepo<Facility>().Delete(facility);
            _unitOfWork.GetRepo<Facility>().SaveChanges();
        }
    }
    
}
