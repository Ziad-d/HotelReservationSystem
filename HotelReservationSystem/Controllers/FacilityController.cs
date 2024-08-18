using ExaminationSystem.Helpers;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.Rooms;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            this.facilityService = facilityService;
        }
        [HttpGet]
        public IEnumerable<FacilityDto> GetAllFacilities()
        {
            var facilities = facilityService.GetAllFacilities();
            return facilities;
            
        }

        [HttpGet("id")]
        public FacilityDto GetRoomById(int id)
        {
            var facility = facilityService.GetFacilityById(id);
            return facility;
        }


        [HttpPost]
        public bool Create(FacilityViewModel viewModel)
        {
            var facility = viewModel.MapOne<FacilityDto>();
            facilityService.Add(facility);
            return true;
        }
    }
}
