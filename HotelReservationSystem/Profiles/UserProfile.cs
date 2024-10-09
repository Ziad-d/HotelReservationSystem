using AutoMapper;
using HotelReservationSystem.DTOs.FacilityDTOs;
using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>();
            CreateMap<UserRegisterDTO, UserForTokenDTO>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserLoginDTO, UserForTokenDTO>();
            CreateMap<User, UserForTokenDTO>();
        }
    }
}
