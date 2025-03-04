using ApplicationLayer.DTOAttandaceAndService;
using ApplicationLayer.InterServLeaveAttandace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attendanceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        [Authorize]
        public async Task<IActionResult> GetByEmployeeId(Guid employeeId)
        {
            var result = await _attendanceService.GetByEmployeeIdAsync(employeeId);

            if (result == null || !result.Any())
            {
                return NotFound("No attendance records found for this employee.");
            }

            return Ok(result);
        }

        [HttpPost("clockin")]
        [Authorize]
        public async Task<IActionResult> ClockIn([FromBody] AttendanceCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _attendanceService.ClockInAsync(dto);

            if (!result)
            {
                return BadRequest("Already clocked in. Please clock out first.");
            }

            return Ok("Clocked in successfully.");
        }


        [HttpPut("clockout")]
        [Authorize]
        public async Task<IActionResult> ClockOut([FromBody] AttendanceUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _attendanceService.ClockOutAsync(dto);

            if (!result)
            {
                return BadRequest("Failed to clock out. Please try again.");
            }

            return Ok("Clocked out successfully.");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _attendanceService.DeleteAsync(id);

            if (!result)
            {
                return BadRequest("Failed to delete attendance record.");
            }

            return Ok("Attendance record deleted successfully.");
        }
    }
}
