using HotelReservationSystem.DTOs.RoleDTOs;

namespace HotelReservationSystem.Services.RoleServices
{
    public interface IRoleService
    {
        RoleToReturnDTO GetRoleById(int id);
    }
}