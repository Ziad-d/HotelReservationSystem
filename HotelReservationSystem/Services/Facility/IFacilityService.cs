using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IFacilityService
    {
        void Add(FacilityDto facilityDto);
        IEnumerable<FacilityDto> GetAllFacilities();
        FacilityDto GetFacilityById(int id);

    }
}
