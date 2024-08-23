using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models.Reservations;
using HotelReservationSystem.Models.Rooms;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile() 
        {
            CreateMap<ReservationToCreateDTO, Reservation>().ReverseMap();
            CreateMap<ReservationToCreateViewModel, ReservationToCreateDTO>();

            CreateMap<ReservationToUpdateDTO, Reservation>().ReverseMap();
            CreateMap<ReservationToUpdateViewModel, ReservationToUpdateDTO>();

            CreateMap<ReservationToReturnDTO, Reservation>().ReverseMap();
            CreateMap<ReservationToReturnViewModel, ReservationToReturnDTO>().ReverseMap();
        }
    }
}
