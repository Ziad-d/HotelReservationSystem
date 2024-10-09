namespace HotelReservationSystem.Services.UserRoleServices
{
    public interface IUserRoleService
    {
        Task<IEnumerable<int>> GetRolesByUserId(int userId);
    }
}