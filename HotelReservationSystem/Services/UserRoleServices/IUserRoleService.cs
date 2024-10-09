using HotelReservationSystem.DTOs.UserDTOs;

namespace HotelReservationSystem.Services.UserRoleServices
{
    public interface IUserRoleService
    {
        Task<IEnumerable<int>> GetRolesByUserId(int userId);
        Task AddRolesToUser(RolesToUserDTO rolesToUserDTO);
    }
}