using HotelReservationSystem.DTOs.RoleDTOs;

namespace HotelReservationSystem.Mediators.RoleMediators
{
    public interface IRoleMediator
    {
        Task<dynamic> AssignFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO);
    }
}