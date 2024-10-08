﻿using HotelReservationSystem.DTOs.RoomDTOs;

namespace HotelReservationSystem.Services.RoomServices
{
    public interface IRoomService
    {
        void Add(RoomToCreateDTO roomDTO);
        void Update(int id, RoomToUpdateDTO roomDTO);
        IEnumerable<RoomToReturnDTO> GetRooms();
        IEnumerable<RoomToReturnDTO> GetAvailableRooms();
        RoomToReturnDTO GetRoomById(int id);
        void Delete(int id);
    }
}
