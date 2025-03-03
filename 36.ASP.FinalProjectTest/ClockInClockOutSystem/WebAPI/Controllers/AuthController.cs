using ApplicationLayer.DTOS;
using ApplicationLayer.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterUserAsync(model);

            if (result.Message == "User already exists.")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginUserAsync(model);

            if (string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _authService.LogoutUserAsync();

            return Ok(result);
        }
    }
}
