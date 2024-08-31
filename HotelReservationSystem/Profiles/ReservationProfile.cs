using AutoMapper;
using HotelReservationSystem.DTOs.ReservationDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.ReservationViewModels;

namespace HotelReservationSystem.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile() 
        {
            CreateMap<ReservationToCreateDTO, Reservation>();
            //    .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.RoomIDs))
            //    //.ForMember(dest => dest.NumberOfReservedDays, opt =>
            //    //    opt.MapFrom(src => (src.CheckOutDate - src.CheckInDate).Days))
            //    .ForMember(dest => dest.IsCanceled, opt => opt.Ignore());
            CreateMap<ReservationToCreateViewModel, ReservationToCreateDTO>();

            CreateMap<ReservationToUpdateDTO, Reservation>().ReverseMap();
            CreateMap<ReservationToUpdateViewModel, ReservationToUpdateDTO>();

            CreateMap<ReservationToReturnDTO, Reservation>().ReverseMap();
            CreateMap<ReservationToReturnViewModel, ReservationToReturnDTO>().ReverseMap();
        }
    }
}
