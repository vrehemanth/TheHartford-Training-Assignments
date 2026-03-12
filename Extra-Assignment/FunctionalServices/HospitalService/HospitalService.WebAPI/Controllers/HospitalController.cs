using HospitalService.Application.DTOs;
using HospitalService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/hospital")]
    [Authorize]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalLogic _logic;

        public HospitalController(HospitalLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [AllowAnonymous] // Anyone can view hospitals
        public async Task<IActionResult> GetAll()
        {
            var hospitals = await _logic.GetAllHospitalsAsync();
            return Ok(hospitals);
        }

        [HttpPost]
        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Add(AddHospitalRequest request)
        {
            try
            {
                await _logic.AddHospitalAsync(request);
                return Ok("Hospital added successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/beds")]
        [Authorize(Roles = "Hospital,Responder")]
        public async Task<IActionResult> UpdateBeds(int id, UpdateBedsRequest request)
        {
            try
            {
                var result = await _logic.UpdateBedsAsync(id, request.AvailableBeds);
                if (!result) return NotFound("Hospital not found");
                return Ok("Bed availability updated");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _logic.DeleteHospitalAsync(id);
            if (!result) return NotFound("Hospital not found");
            return Ok("Hospital removed");
        }
    }
}
