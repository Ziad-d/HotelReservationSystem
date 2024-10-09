using AutoMapper.Features;
using Azure.Core;
using HotelReservationSystem.DTOs.RoleDTOs;
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

        public async Task AddFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO)
        {
            foreach (var feature in featuresToRoleDTO.Features)
            {
                var existingRoleFeature = await _unitOfWork.GetRepo<RoleFeature>().First(
                            rf => rf.RoleID == featuresToRoleDTO.RoleId && rf.Feature == feature
                        );

                if (existingRoleFeature == null)
                {
                    var roleFeature = new RoleFeature
                    {
                        RoleID = featuresToRoleDTO.RoleId,
                        Feature = feature
                    };

                    await _unitOfWork.GetRepo<RoleFeature>().AddAsync(roleFeature);
                }
            }
            await _unitOfWork.GetRepo<RoleFeature>().SaveChangesAsync();
        }
    }
}
