using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> repository;

        public RoomService(IRepository<Room> repository)
        {
            this.repository = repository;
        }

        public void Add(RoomToCreateDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();
            repository.Add(room);
            repository.SaveChanges();
        }
    }
}
