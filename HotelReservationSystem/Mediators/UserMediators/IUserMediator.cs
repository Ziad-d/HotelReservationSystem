using HotelReservationSystem.DTOs.UserDTOs;

namespace HotelReservationSystem.Mediators.UserMediators
{
    public interface IUserMediator
    {
        Task<string> LoginAsync(UserLoginDTO loginDTO);
        Task<string> RegisterAsync(UserRegisterDTO registerDTO);
    }
}