using AutoMapper;
using HotelReservationSystem.DTOs.FeedbackDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.FeedbackViewModels;

namespace HotelReservationSystem.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile() 
        {
            CreateMap<FeedbackToCreateDTO, Feedback>().ReverseMap();
            CreateMap<FeedbackToCreateViewModel, FeedbackToCreateDTO>();

            CreateMap<FeedbackToReturnDTO, Feedback>().ReverseMap();
            CreateMap<FeedbackToReturnViewModel, FeedbackToReturnDTO>().ReverseMap();

           
        }
    }
}
