namespace ExaminationSystem.Exceptions
{
    public enum ErrorCode
    {
        None = 0,
        UnKnown = 1,

        RoomNotFound = 1000,

        ReservationNotFound = 2000,
        NotValidReservationID = 2001,
        NotValidDates = 2002,
        ReservationWasCancelled = 2003
    }
}
