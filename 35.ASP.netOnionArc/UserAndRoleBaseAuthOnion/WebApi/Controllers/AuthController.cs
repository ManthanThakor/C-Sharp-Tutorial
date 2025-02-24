using Application.DTO;
using Application.Services.UserSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private const int RefreshTokenExpiryDays = 7;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(registerDto);
                return CreateAuthResponse(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);

                var refreshToken = Request.Cookies["refreshToken"];

                return CreateAuthResponse(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshToken))
                    return BadRequest(new { message = "Refresh token is required" });

                var result = await _authService.RefreshTokenAsync(refreshToken);

                SetRefreshTokenCookie(refreshToken);

                return Ok(new { accessToken = result.AccessToken, expiresAt = result.ExpiresAt });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var refreshToken = Request.Cookies["refreshToken"];

                if (string.IsNullOrEmpty(refreshToken))
                    return BadRequest(new { message = "Refresh token is required" });

                var result = await _authService.LogoutAsync(refreshToken);

                Response.Cookies.Delete("refreshToken");

                return Ok(new { message = "Logged out successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private IActionResult CreateAuthResponse(AuthResponseDto authResponse)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            SetRefreshTokenCookie(refreshToken);

            return Ok(new
            {
                accessToken = authResponse.AccessToken,
                username = authResponse.Username,
                email = authResponse.Email,
                role = authResponse.Role
            });
        }

        private void SetRefreshTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(RefreshTokenExpiryDays),
                SameSite = SameSiteMode.Strict,
                Secure = true
            };

            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}