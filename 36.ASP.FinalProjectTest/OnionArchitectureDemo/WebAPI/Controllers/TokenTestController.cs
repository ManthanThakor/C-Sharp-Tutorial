using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        private readonly ILogger<TokenTestController> _logger;

        public TokenTestController(ILogger<TokenTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            var authHeader = Request.Headers.Authorization.ToString();
            _logger.LogInformation("Authorization header: {AuthHeader}", authHeader);

            if (string.IsNullOrEmpty(authHeader))
            {
                return BadRequest("No Authorization header provided");
            }

            return Ok(new { Message = "Header received", Header = authHeader });
        }

        [Authorize]
        [HttpGet("test-jwt")]
        public IActionResult TestJwt()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(new { Message = "JWT is valid", Claims = claims });
        }
    }
}
