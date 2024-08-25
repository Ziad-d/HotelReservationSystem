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
    [Route("[controller]/[action]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public IEnumerable<FacilityToReturnViewModel> GetAllFacilities()
        {
            var facilities = _facilityService.GetAllFacilities();
            return facilities.Select(x => x.MapOne<FacilityToReturnViewModel>());
            
        }

        [HttpGet("{id}")]
        public FacilityToReturnViewModel GetFacilityById(int id)
        {
            var facility = _facilityService.GetFacilityById(id);
            return facility.MapOne<FacilityToReturnViewModel>();
        }


        [HttpPost]
        public bool CreateFacility(FacilityToCreateViewModel viewModel)
        {
            var facility = viewModel.MapOne<FacilityToCreateDTO>();
            _facilityService.Add(facility);
            return true;
        }

        [HttpPut]
        public bool UpdateFacility(int id, FacilityToUpdateViewModel viewModel)
        {
            var facilityDTO = viewModel.MapOne<FacilityToUpdateDTO>();
            _facilityService.Update(id, facilityDTO);
            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _facilityService.Delete(id);
            return true;
        }
    }
}
