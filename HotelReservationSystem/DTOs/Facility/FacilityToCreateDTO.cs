namespace HotelReservationSystem.DTOs.Room
{
    public class FacilityToCreateDTO
    {
        public decimal Price { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
