using Azure.Core;
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
    }
}
