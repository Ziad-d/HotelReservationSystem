namespace HotelReservationSystem.Services.RoomReservationServices
{
    public interface IRoomReservationService
    {
        void ReserveRooms(int reservationID, List<int> roomsNumber);
    }
}
