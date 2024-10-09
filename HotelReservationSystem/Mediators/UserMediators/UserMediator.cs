using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.UserServices;

namespace HotelReservationSystem.Mediators.UserMediators
{
    public class UserMediator : IUserMediator
    {
        private readonly IUserService _userService;

        public UserMediator(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<string> LoginAsync(UserLoginDTO loginDTO)
        {
            var user = await _userService.FindUserByEmailAsync(loginDTO.EmailAddress);

            if (user is null || !await _userService.CheckUserPasswordAsync(user, loginDTO.Password))
            {
                return "Invalid Credentails";
            }
            var userForToken = user.MapOne<UserForTokenDTO>();
            var token = TokenGenerator.GenerateToken(userForToken);

            return token;
        }

        public async Task<string> RegisterAsync(UserRegisterDTO registerDTO)
        {
            var userEmailAddress = await _userService.FindUserByEmailAsync(registerDTO.EmailAddress);

            if (userEmailAddress is not null)
            {
                return "Email Address is already registered!";
            }

            var userUserName = await _userService.FindUserByUserNameAsync(registerDTO.UserName);

            if (userUserName is not null)
            {
                return "Username is already registered!";
            }

            await _userService.CreateUserAsync(registerDTO);

            var userForToken = registerDTO.MapOne<UserForTokenDTO>();

            var token = TokenGenerator.GenerateToken(userForToken);

            return token;
        }
    }
}
