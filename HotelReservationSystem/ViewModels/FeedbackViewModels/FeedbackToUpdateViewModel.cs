
namespace HotelReservationSystem.ViewModels.FeedbackViewModels
{
    public class FeedbackToUpdateViewModel
    {
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}
