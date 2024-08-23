using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.ViewModels.Room;

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
