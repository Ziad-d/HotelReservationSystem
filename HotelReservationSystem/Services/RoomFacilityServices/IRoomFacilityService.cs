namespace HotelReservationSystem.Services.RoomFacilityServices
{
    public interface IRoomFacilityService
    {
        void AddFacilitiesToRoom(int roomID, HashSet<int> facilityIDs);
    }
}
