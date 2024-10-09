using Azure.Core;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services.RoleFeatureServices
{
    public class RoleFeatureService : IRoleFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleFeatureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckRoleFeatureAccess(int roleId, Feature feature)
        {
            var hasAccess = await _unitOfWork.GetRepo<RoleFeature>().Get(r => !r.IsDeleted &&
                        r.RoleID == roleId &&
                        r.Feature == feature)
                        .AnyAsync();

            return hasAccess;
        }
    }
}
