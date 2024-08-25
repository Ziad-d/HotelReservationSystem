using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.Repositories.UnitOfWork;

namespace HotelReservationSystem.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(RoomToCreateDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();
            _unitOfWork.GetRepo<Room>().Add(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
        }

        public void Update(int id, RoomToUpdateDTO roomDTO)
        {
            var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Room not found");

            //room.Price = roomDTO.Price;
            //room.PictureUrl = roomDTO.PictureUrl;
            //room.IsAvailable = roomDTO.IsAvailable;
            //room.Description = roomDTO.Description;
            //room.RoomType = roomDTO.RoomType;
            //room.Facilities = roomDTO.Facilities;

            //_repository.Update(room);
            roomDTO.MapOne(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
        }

        public IEnumerable<RoomToReturnDTO> GetAvailableRooms()
        {
            var availableRooms = _unitOfWork.GetRepo<Room>().Get(r => r.IsAvailable == true );

            return availableRooms.Map<RoomToReturnDTO>();
        }

        public RoomToReturnDTO GetRoomById(int id)
        {
            var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id);
            return room.MapOne<RoomToReturnDTO>();
        }

        public IEnumerable<RoomToReturnDTO> GetRooms()
        {
            var rooms = _unitOfWork.GetRepo<Room>().GetAll();
            return rooms.Map<RoomToReturnDTO>();
        }

        public void Delete(int id)
        {
            var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id);
            _unitOfWork.GetRepo<Room>().Delete(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
        }
    }
}
