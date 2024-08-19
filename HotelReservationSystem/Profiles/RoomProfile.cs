using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Room;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomToCreateDTO, Room>().ReverseMap();
            CreateMap<RoomToCreateViewModel, RoomToCreateDTO>();
            
        }
    }
}
