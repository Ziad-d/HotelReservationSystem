
using HotelReservationSystem.DTOs.FeedbackDTOs;

namespace HotelReservationSystem.Services.FeedbackServices
{
    public interface IFeedbackService
    {
        void Add(FeedbackToCreateDTO feedbackToCreateDTO);
        IEnumerable<FeedbackToReturnDTO> GetAll();
        FeedbackToReturnDTO GetById(int id);
        void Delete(int id);
       
    }
}
