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
            return Ok(result);
        }

        [HttpPost("clockin")]
        [Authorize]
        public async Task<IActionResult> ClockIn([FromBody] AttendanceCreateDto dto)
        {
            var result = await _attendanceService.ClockInAsync(dto);
            return result ? Ok("Clocked in successfully") : BadRequest("Failed to clock in");
        }

        [HttpPut("clockout")]
        [Authorize]
        public async Task<IActionResult> ClockOut([FromBody] AttendanceUpdateDto dto)
        {
            var result = await _attendanceService.ClockOutAsync(dto);
            return result ? Ok("Clocked out successfully") : BadRequest("Failed to clock out");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _attendanceService.DeleteAsync(id);
            return result ? Ok("Deleted successfully") : BadRequest("Failed to delete");
        }
    }
}
