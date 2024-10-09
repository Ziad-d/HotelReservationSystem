using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoleServices
{
    public interface IRoleService
    {
        Task<RoleToReturnDTO> GetRoleById(int id);
        Task<Role> AddRole(RoleToCreateDTO roleToCreateDTO);
    }
}