using AutoMapper;
using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleToCreateDTO, Role>();
            CreateMap<Role, RoleToReturnDTO>().ReverseMap();
        }
    }
}
