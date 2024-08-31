using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.RoomDTOs;
using HotelReservationSystem.Models;
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

        public async Task<Room> AddAsync(RoomToCreateDTO roomDTO)
        {
            var room = roomDTO.MapOne<Room>();
            await _unitOfWork.GetRepo<Room>().AddAsync(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
            return room;
        }

        public void Update(int id, RoomToUpdateDTO roomDTO)
        {
            var room = _unitOfWork.GetRepo<Room>().GetByIDWithTracking(id) ?? throw new KeyNotFoundException("Room not found");

            roomDTO.MapOne(room);
            _unitOfWork.GetRepo<Room>().SaveChanges();
        }

        public RoomToReturnDTO GetRoomById(int id)
        {
            var room = _unitOfWork.GetRepo<Room>()
                .GetByID(id)
                .Map<RoomToReturnDTO>()
                .FirstOrDefault();
            return room;
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
