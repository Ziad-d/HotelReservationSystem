using HotelReservationSystem.Enums;

namespace HotelReservationSystem.Services.RoleFeatureServices
{
    public interface IRoleFeatureService
    {
        Task<bool> CheckRoleFeatureAccess(int roleId, Feature feature);
    }
}