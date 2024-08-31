using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Services.RoomReservationServices;

namespace HotelReservationSystem.Mediators.ReservationMediators
{
    public class ReservationMediator : IReservationMediator
    {
        private readonly IReservationService _reservationService;
        private readonly IRoomReservationService _roomReservationService;

        public ReservationMediator(IReservationService reservationService, IRoomReservationService roomReservationService) 
        {
            _reservationService = reservationService;
            _roomReservationService = roomReservationService;
        }

        public async Task<ReservationToReturnDTO> Add(ReservationToCreateDTO reservationDTO)
        {
            var reservationToAdd = await _reservationService.AddAsync(reservationDTO);
            _roomReservationService.ReserveRooms(reservationToAdd.ID, reservationDTO.RoomsNumber);
            var mappedReservation = reservationToAdd.MapOne<ReservationToReturnDTO>();

            return mappedReservation;
        }
    }
}
