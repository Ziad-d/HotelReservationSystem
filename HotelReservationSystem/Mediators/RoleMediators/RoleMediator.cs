using Azure.Core;
using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.Mediators.RoomMediators;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.RoleFeatureServices;
using HotelReservationSystem.Services.RoleServices;

namespace HotelReservationSystem.Mediators.RoleMediators
{
    public class RoleMediator : IRoleMediator
    {
        private readonly IRoleService _roleService;
        private readonly IRoleFeatureService _roleFeatureService;

        public RoleMediator(IRoleService roleService, IRoleFeatureService roleFeatureService) 
        {
            _roleService = roleService;
            _roleFeatureService = roleFeatureService;
        }

        public async Task<dynamic> AssignFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO)
        {
            if (featuresToRoleDTO == null || featuresToRoleDTO.Features.Any())
            {
                return "Invalid Inputs";
            }

            var role = await _roleService.GetRoleById(featuresToRoleDTO.RoleId);
            if (role == null)
            {
                return "Invalid RoleID!";
            }

            await _roleFeatureService.AddFeaturesToRole(featuresToRoleDTO);

            return "Features assigned to role successfully!";
        }
    }
}
