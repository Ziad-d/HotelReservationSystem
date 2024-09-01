
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.FeedbackDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.FeedbackServices;
using HotelReservationSystem.ViewModels.FeedbackViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpGet]

        public IEnumerable<FeedbackToReturnViewModel> GetAllFeedbacks()
        {

            var feedbacks = _feedbackService.GetAll();
            return feedbacks.Select(x => x.MapOne<FeedbackToReturnViewModel>());
        }

        [HttpDelete]
        public bool DeleteFeedback(int id)
        {

            _feedbackService.Delete(id);
            return true;

        }

        [HttpGet("id")]
        public FeedbackToReturnViewModel GetFeedbackById(int id)
        {
            var feedback = _feedbackService.GetById(id);
            return feedback.MapOne<FeedbackToReturnViewModel>();
        }

        [HttpPost]
        public bool CreateFeedback(FeedbackToCreateViewModel feedbackToCreateViewModel)
        {
            var feedback = feedbackToCreateViewModel.MapOne<FeedbackToCreateDTO>();
            _feedbackService.Add(feedback);
            return true ;
        }
    }
}