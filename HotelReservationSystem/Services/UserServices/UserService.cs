using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.GetRepo<User>().First(u => u.EmailAddress == email);

            return user;
        }

        public async Task<bool> CheckUserPasswordAsync(User user, string password)
        {
            var checkedUser = await FindUserByEmailAsync(user.EmailAddress);

            if (checkedUser == null || !BCrypt.Net.BCrypt.Verify(password, checkedUser.Password))
            {
                return false;
            }

            return true;
        }

        public async Task<User> FindUserByUserNameAsync(string username)
        {
            var user = await _unitOfWork.GetRepo<User>().First(u => u.UserName == username);

            return user;
        }

        public async Task<User> CreateUserAsync(UserRegisterDTO registerDTO)
        {
            var user = registerDTO.MapOne<User>();

            user.Password = PasswordHelper.CreatePasswordHash(registerDTO.Password);

            await _unitOfWork.GetRepo<User>().AddAsync(user);
            _unitOfWork.GetRepo<User>().SaveChanges();

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _unitOfWork.GetRepo<User>().First(u => u.ID == id);
            return user;
        }
    }
}
