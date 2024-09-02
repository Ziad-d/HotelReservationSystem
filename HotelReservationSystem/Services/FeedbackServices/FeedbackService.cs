

using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.FeedbackDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.FeedbackServices
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(FeedbackToCreateDTO feedbackToCreateDTO)
        {
        
            var feedback = feedbackToCreateDTO.MapOne<Feedback>() ;
             _unitOfWork.GetRepo<Feedback>().Add(feedback);
            _unitOfWork.GetRepo<Feedback>().SaveChanges();

        }

        public void Delete(int id)
        {
            var feedback =_unitOfWork.GetRepo<Feedback>().GetByIDWithTracking(id);
            _unitOfWork.GetRepo<Feedback>().Delete(feedback);
            _unitOfWork.GetRepo<Feedback>().SaveChanges();

        }

        public IEnumerable<FeedbackToReturnDTO> GetAll()
        {
            var feedbacks = _unitOfWork.GetRepo<Feedback>().GetAll();
            return feedbacks.Map<FeedbackToReturnDTO>();
        }

        public FeedbackToReturnDTO GetById(int id)
        {
            var feedback = _unitOfWork.GetRepo<Feedback>()
                .GetByID(id)
                .Map<FeedbackToReturnDTO>()
                .FirstOrDefault();
            return feedback;
        }

    }

}
