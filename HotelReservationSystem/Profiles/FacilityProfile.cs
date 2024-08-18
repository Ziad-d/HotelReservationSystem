using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Room;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() 
        {
            CreateMap<FacilityDto, Facility>().ReverseMap();
            CreateMap<FacilityViewModel, FacilityDto>();
        }
    }
}
