using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IFacilityService
    {
        void Add(FacilityToCreateDTO facilityDto);
        IEnumerable<FacilityToReturnDTO> GetAllFacilities();
        FacilityToReturnDTO GetFacilityById(int id);
        void Update(int id, FacilityToUpdateDTO facilityDTO);
        void Delete(int id);
    }
}
