using AutoMapper;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.ViewModels.RoomViewModels;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomToCreateDTO, Room>().ReverseMap();
            CreateMap<RoomToCreateViewModel, RoomToCreateDTO>();

            CreateMap<RoomToUpdateDTO, Room>().ReverseMap();
            CreateMap<RoomToUpdateViewModel, RoomToUpdateDTO>();

            CreateMap<RoomToReturnDTO, Room>().ReverseMap();
            CreateMap<RoomToReturnViewModel, RoomToReturnDTO>().ReverseMap();
        }
    }
}
