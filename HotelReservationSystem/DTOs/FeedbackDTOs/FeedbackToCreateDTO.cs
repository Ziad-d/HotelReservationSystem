namespace HotelReservationSystem.DTOs.FeedbackDTOs
{
    public class FeedbackToCreateDTO
    {
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}
