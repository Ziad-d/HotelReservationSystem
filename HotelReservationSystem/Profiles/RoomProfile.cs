using AutoMapper;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.RoomViewModels;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomToCreateDTO, Room>().ReverseMap();
            CreateMap<RoomToCreateViewModel, RoomToCreateDTO>().ReverseMap();

            CreateMap<RoomToUpdateDTO, Room>()
            .ForMember(dest => dest.RoomNumber, opt => opt.Condition(src => src.RoomNumber.HasValue))
            .ForMember(dest => dest.Price, opt => opt.Condition(src => src.Price.HasValue))
            .ForMember(dest => dest.IsAvailable, opt => opt.Condition(src => src.IsAvailable.HasValue))
            .ForMember(dest => dest.RoomType, opt => opt.Condition(src => src.RoomType != null));
            CreateMap<RoomToUpdateViewModel, RoomToUpdateDTO>();

            CreateMap<Room, RoomToReturnDTO>()
            .ForMember(dest => dest.Facilities, opt =>
            opt.MapFrom(src => src.RoomFacilities.Select(rf => rf.Facility.Name)));
            CreateMap<RoomToReturnDTO, RoomToReturnViewModel>();
        }
    }
}
