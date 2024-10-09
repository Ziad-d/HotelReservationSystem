using Azure.Core;
using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.UserRoleServices
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<int>> GetRolesByUserId(int userId)
        {
            var userRoles = _unitOfWork.GetRepo<UserRole>().Get(ur => ur.UserId == userId);

            var roleIds = userRoles.Select(r => r.RoleId).ToList();

            return roleIds;
        }

        public async Task AddRolesToUser(RolesToUserDTO rolesToUserDTO)
        {
            foreach (var roleId in rolesToUserDTO.RoleIds)
            {
                var existingUserRole = await _unitOfWork.GetRepo<UserRole>().First(
                    ur => ur.UserId == rolesToUserDTO.UserId && ur.RoleId == roleId
                );

                if (existingUserRole == null)
                {
                    var userRole = new UserRole
                    {
                        UserId = rolesToUserDTO.UserId,
                        RoleId = roleId
                    };

                    await _unitOfWork.GetRepo<UserRole>().AddAsync(userRole);
                }
            }
            await _unitOfWork.GetRepo<UserRole>().SaveChangesAsync();
        }
    }
}
