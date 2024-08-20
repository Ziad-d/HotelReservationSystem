using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomToCreateDTO, Room>();
            CreateMap<RoomToCreateViewModel, RoomToCreateDTO>();

            CreateMap<RoomToUpdateDTO, Room>().ReverseMap();
            CreateMap<RoomToUpdateViewModel, RoomToUpdateDTO>();

            CreateMap<RoomToReturnDTO, Room>().ReverseMap();
            CreateMap<RoomToReturnViewModel, RoomToReturnDTO>().ReverseMap();
        }
    }
}
