using EmergencyService.Application.DTOs;
using EmergencyService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmergencyService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/emergency")]
    [Authorize]
    public class EmergencyController : ControllerBase
    {
        private readonly EmergencyLogic _logic;

        public EmergencyController(EmergencyLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("report")]
        [Authorize(Roles = "Victim")]
        public async Task<IActionResult> Report(ReportEmergencyRequest request)
        {
            try
            {
                var victimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Unknown";
                await _logic.ReportAsync(request, victimId);
                return Ok("Emergency reported successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("accept/{id}")]
        [Authorize(Roles = "Responder")]
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                var responderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Unknown";
                var result = await _logic.AcceptAsync(id, responderId);
                if (!result) return NotFound("Emergency not found");
                return Ok("Emergency accepted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Hospital,Responder")]
        public async Task<IActionResult> GetAll()
        {
            var emergencies = await _logic.GetAllEmergenciesAsync();
            return Ok(emergencies);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Victim,Responder")]
        public async Task<IActionResult> Update(int id, UpdateEmergencyRequest request)
        {
            var result = await _logic.UpdateAsync(id, request);
            if (!result) return NotFound("Emergency not found");
            return Ok("Emergency updated successfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Victim")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _logic.DeleteAsync(id);
            if (!result) return NotFound("Emergency not found");
            return Ok("Emergency deleted successfully");
        }

        [HttpPost("{id}/assign-hospital/{hospitalId}")]
        [Authorize(Roles = "Responder")]
        public async Task<IActionResult> AssignHospital(int id, int hospitalId)
        {
            try
            {
                await _logic.AssignHospitalAsync(id, hospitalId);
                return Ok($"Hospital {hospitalId} assigned to emergency {id} and bed reserved.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
