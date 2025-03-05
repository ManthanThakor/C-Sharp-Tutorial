using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/home")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Welcome()
        {
            return Ok(new { Message = "Welcome to the Attendance Management API." });
        }

        [HttpGet("metadata")]
        public IActionResult GetMetadata()
        {
            var metadata = new
            {
                API_Name = "Attendance & Leave Management System",
                Version = "1.0",
                Description = "API for managing employee attendance and leave.",
                Author = "Manthan"
            };

            return Ok(metadata);
        }

        [HttpGet("health")]
        [AllowAnonymous]
        public IActionResult HealthCheck()
        {
            return Ok(new { Status = "API is running fine." });
        }

        [HttpGet("routes")]
        public IActionResult GetRoutes()
        {
            var routes = new[]
            {
                new { Method = "POST", Route = "/api/auth/register", Description = "Register a new user" },
                new { Method = "POST", Route = "/api/auth/login", Description = "Login and get JWT token" },
                new { Method = "POST", Route = "/api/auth/logout", Description = "Logout the user" },
                new { Method = "GET", Route = "/api/attendance/all", Description = "Get all attendance records (Admin only)" },
                new { Method = "GET", Route = "/api/attendance/{employeeId}", Description = "Get employee attendance" },
                new { Method = "POST", Route = "/api/attendance/clockin", Description = "Clock-in an employee" },
                new { Method = "PUT", Route = "/api/attendance/clockout", Description = "Clock-out an employee" },
                new { Method = "DELETE", Route = "/api/attendance/{id}", Description = "Delete an attendance record (Admin only)" }
            };

            return Ok(new { AvailableRoutes = routes });
        }
    }
}
