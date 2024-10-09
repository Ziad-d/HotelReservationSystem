using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.UserServices
{
    public interface IUserService
    {
        Task<User> FindUserByEmailAsync(string email);
        Task<bool> CheckUserPasswordAsync(User user, string password);
        Task<User> FindUserByUserNameAsync(string username);
        Task<User> CreateUserAsync(UserRegisterDTO registerDTO);
    }
}