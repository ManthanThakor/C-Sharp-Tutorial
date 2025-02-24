using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicRoute()
        {
            return Ok(new
            {
                Message = "🚀 This is a public route. No authentication required."
            });
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedRoute()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Message = "Unauthorized! You need to log in first."
                });
            }

            return Ok(new
            {
                Message = "You have accessed a protected route!",
                User = User.Identity?.Name
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminRoute()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized(new
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Message = "Unauthorized! You need to log in first."
                });
            }

            if (!User.IsInRole("Admin"))
            {
                return StatusCode(StatusCodes.Status403Forbidden, new
                {
                    Status = StatusCodes.Status403Forbidden,
                    Message = "Access Denied! Only admins can access this route."
                });
            }

            return Ok(new
            {
                Message = "Only admins can access this route!",
                User = User.Identity?.Name
            });
        }
    }
}
