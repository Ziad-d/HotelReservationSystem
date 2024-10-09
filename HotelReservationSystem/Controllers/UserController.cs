using HotelReservationSystem.DTOs.UserDTOs;
using HotelReservationSystem.Mediators.UserMediators;
using HotelReservationSystem.Services.UserServices;
using HotelReservationSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMediator _userMediator;

        public UserController(IUserMediator userMediator)
        {
            _userMediator = userMediator;
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Register(UserRegisterDTO user)
        {
            var result = await _userMediator.RegisterAsync(user);

            return ResponseViewModel<bool>.Sucess(true, result);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Login(UserLoginDTO user)
        {
            var result = await _userMediator.LoginAsync(user);

            return ResponseViewModel<bool>.Sucess(true, result);
        }
    }
}
