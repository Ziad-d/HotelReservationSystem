using AutoMapper;
using HotelReservationSystem.DTOs.FacilityDTOs;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.ViewModels.FacilityViewModels;

namespace HotelReservationSystem.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile() 
        {
            CreateMap<FacilityToCreateDTO, Facility>().ReverseMap();
            CreateMap<FacilityToCreateViewModel, FacilityToCreateDTO>();

            CreateMap<FacilityToReturnDTO, Facility>().ReverseMap();
            CreateMap<FacilityToReturnViewModel, FacilityToReturnDTO>().ReverseMap();

            CreateMap<FacilityToUpdateDTO, Facility>().ReverseMap();
            CreateMap<FacilityToUpdateViewModel, FacilityToUpdateDTO>().ReverseMap();
        }
    }
}
