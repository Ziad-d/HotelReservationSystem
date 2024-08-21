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
        private readonly IRepository<Room> _repository;

        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public void Add(RoomToCreateDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();
            _repository.Add(room);
            _repository.SaveChanges();
        }

        public void Update(int id, RoomToUpdateDTO roomDTO)
        {
            var room = _repository.GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Room not found");

            //room.Price = roomDTO.Price;
            //room.PictureUrl = roomDTO.PictureUrl;
            //room.IsAvailable = roomDTO.IsAvailable;
            //room.Description = roomDTO.Description;
            //room.RoomType = roomDTO.RoomType;
            //room.Facilities = roomDTO.Facilities;

            //_repository.Update(room);
            roomDTO.MapOne(room);
            _repository.SaveChanges();
        }

        public IEnumerable<RoomToReturnDTO> GetAvailableRooms()
        {
            var availableRooms = _repository.Get(r => r.IsAvailable == true);

            return availableRooms.Map<RoomToReturnDTO>();
        }

        public RoomToReturnDTO GetRoomById(int id)
        {
            var room = _repository.GetByIDWithTracking(id);
            return room.MapOne<RoomToReturnDTO>();
        }

        public IEnumerable<RoomToReturnDTO> GetRooms()
        {
            var rooms = _repository.GetAll();
            return rooms.Map<RoomToReturnDTO>();
        }

        public void Delete(int id)
        {
            var room = _repository.GetByIDWithTracking(id);
            _repository.Delete(room);
            _repository.SaveChanges();
        }
    }
}
