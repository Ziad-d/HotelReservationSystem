namespace HotelReservationSystem.DTOs.FacilityDTOs
{
    public class FacilityToUpdateDTO
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
