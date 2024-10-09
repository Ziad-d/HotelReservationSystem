using ExaminationSystem.Exceptions;
using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Mediators.RoleMediators;
using HotelReservationSystem.Mediators.UserMediators;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.RoleServices;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRoleMediator _roleMediator;
        private readonly IRoleService _roleService;
        private readonly IUserMediator _userMediator;

        public AdminController(IRoleMediator roleMediator, IRoleService roleService, IUserMediator userMediator)
        {
            _roleMediator = roleMediator;
            _roleService = roleService;
            _userMediator = userMediator;
        }

        [HttpPost]
        public async Task<ResponseViewModel<Role>> CreateRole(RoleToCreateDTO roleToCreateDTO)
        {
            var role = await _roleService.AddRole(roleToCreateDTO);

            if (role == null)
            {
                return ResponseViewModel<Role>.Faliure(ErrorCode.RoleNotFound, "Role is not found!");
            }

            return ResponseViewModel<Role>.Sucess(role);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<RoleToReturnDTO>> GetSingleRole(int id)
        {
            var role = await _roleService.GetRoleById(id);

            if (role == null)
            {
                return ResponseViewModel<RoleToReturnDTO>.Faliure(ErrorCode.RoleNotFound, "Role is not found!");
            }

            return ResponseViewModel<RoleToReturnDTO>.Sucess(role);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AssignFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO)
        {
            var result = await _roleMediator.AssignFeaturesToRole(featuresToRoleDTO);

            return ResponseViewModel<bool>.Sucess(true, result);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AssignRolesToUser(RolesToUserDTO rolesToUserDTO)
        {
            var result = await _userMediator.AssignRolesToUser(rolesToUserDTO);

            return ResponseViewModel<bool>.Sucess(true, result);
        }
    }
}
