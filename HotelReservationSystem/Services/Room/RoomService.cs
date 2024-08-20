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

        public void Update(int id, RoomToUpdateDTO roomDTO)
        {
            var room = repository.GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Room not found");

            //room.Price = roomDTO.Price;
            //room.PictureUrl = roomDTO.PictureUrl;
            //room.IsAvailable = roomDTO.IsAvailable;
            //room.Description = roomDTO.Description;
            //room.RoomType = roomDTO.RoomType;
            //room.Facilities = roomDTO.Facilities;

            //repository.Update(room);
            roomDTO.MapOne(room);
            repository.SaveChanges();
        }

        public IEnumerable<RoomToReturnDTO> GetAvailableRooms()
        {
            var availableRooms = repository.Get(r => r.IsAvailable == true);

            return availableRooms.Map<RoomToReturnDTO>();
        }

        public RoomToReturnDTO GetRoomById(int id)
        {
            var room = repository.GetByIDWithTracking(id);
            return room.MapOne<RoomToReturnDTO>();
        }

        public IEnumerable<RoomToReturnDTO> GetRooms()
        {
            var rooms = repository.GetAll();
            return rooms.Map<RoomToReturnDTO>();
        }

        public void Delete(int id)
        {
            var room = repository.GetByIDWithTracking(id);
            repository.Delete(room);
            repository.SaveChanges();
        }
    }
}
