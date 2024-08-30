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

            CreateMap<RoomToUpdateDTO, Room>();
            CreateMap<RoomToUpdateViewModel, RoomToUpdateDTO>();

            CreateMap<Room, RoomToReturnDTO>()
            .ForMember(dest => dest.Facilities, opt =>
            opt.MapFrom(src => src.RoomFacilities.Select(rf => rf.Facility.Name)));
            CreateMap<RoomToReturnDTO, RoomToReturnViewModel>();
        }
    }
}
