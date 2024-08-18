using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Room;
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

        public IEnumerable<RoomToCreateDTO> GetAvailableRooms()
        {
            var avilableRooms= repository.Get(r=>r.IsAvailable==true);

            return avilableRooms.Map<RoomToCreateDTO>();
        }

        public RoomToCreateDTO GetRoomById(int id)
        {
            var room = repository.GetByIDWithTracking(id);
            return room.MapOne<RoomToCreateDTO>();
        }

        public IEnumerable<RoomToCreateDTO> GetRooms()
        {
            var rooms = repository.GetAll();
            return rooms.Map<RoomToCreateDTO>();
            
        }
    }
}
