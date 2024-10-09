using Azure.Core;
using ExaminationSystem.Exceptions;
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoleDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RoleToReturnDTO> GetRoleById(int id)
        {
            var role = _unitOfWork.GetRepo<Role>().GetByID(id) ?? throw new BusinessException(ErrorCode.RoomNotFound, "Room not found");
            var mappedRole = role.Map<RoleToReturnDTO>().FirstOrDefault();
            return mappedRole;
        }

        public async Task<Role> AddRole(RoleToCreateDTO roleToCreateDTO)
        {
            if (roleToCreateDTO.Name == null)
            {
                throw new BusinessException(ErrorCode.RoleNotFound, "No name was provided");

            }
            var roleFound = await _unitOfWork.GetRepo<Role>().First(r => r.Name == roleToCreateDTO.Name);

            if (roleFound is not null)
            {
                throw new BusinessException(ErrorCode.None, "Role already exists");
            }

            var role = roleToCreateDTO.MapOne<Role>();
            await _unitOfWork.GetRepo<Role>().AddAsync(role);
            await _unitOfWork.GetRepo<Role>().SaveChangesAsync();
            return role;
        }
    }
}
