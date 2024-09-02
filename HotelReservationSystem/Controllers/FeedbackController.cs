
using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.FeedbackDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.FeedbackServices;
using HotelReservationSystem.ViewModels;
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

        public ResponseViewModel<IEnumerable<FeedbackToReturnViewModel>> GetAllFeedbacks()
        {

            var feedbacks = _feedbackService.GetAll();
            var mappedFeedbacks= feedbacks.Select(x => x.MapOne<FeedbackToReturnViewModel>());
            return ResponseViewModel<IEnumerable<FeedbackToReturnViewModel>>.Sucess(mappedFeedbacks);
        }

        [HttpDelete]
        public bool DeleteFeedback(int id)
        {

            _feedbackService.Delete(id);
            return true;

        }

        [HttpGet("id")]
        public ResponseViewModel<FeedbackToReturnViewModel> GetFeedbackById(int id)
        {
            var feedback = _feedbackService.GetById(id);
            var mappedFeedback = feedback.MapOne<FeedbackToReturnViewModel>();
            return ResponseViewModel<FeedbackToReturnViewModel>.Sucess(mappedFeedback);
        }

        [HttpPost]
        public ResponseViewModel<bool> CreateFeedback(FeedbackToCreateViewModel feedbackToCreateViewModel)
        {
            var feedback = feedbackToCreateViewModel.MapOne<FeedbackToCreateDTO>();
             _feedbackService.Add(feedback);
            return ResponseViewModel<bool>.Sucess(true) ;
        }
    }
}