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
        public RoleToReturnDTO GetRoleById(int id)
        {
            var room = _unitOfWork.GetRepo<Room>().GetByID(id) ?? throw new BusinessException(ErrorCode.RoomNotFound, "Room not found");
            var mappedRoom = room.Map<RoleToReturnDTO>().FirstOrDefault();
            return mappedRoom;
        }
    }
}
