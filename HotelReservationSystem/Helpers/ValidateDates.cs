namespace HotelReservationSystem.Helpers
{
    public class ValidateDates
    {
        public static bool ValidateInputDate(DateTime checkIn, DateTime checkOut)
        {
            if (checkIn < DateTime.UtcNow || checkOut < DateTime.UtcNow)
            {
                return false;
            }

            if (checkOut <= checkIn)
            {
                return false;
            }

            return true;
        }
    }
}
