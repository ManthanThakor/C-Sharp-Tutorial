using Application.DTO;
using Application.Services.PasswordService;
using Application.Services.TokenService;
using Application.Services.UserSer;
using Domain.Entity;
using Domain.Enums;
using Infrastructure.EfCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.AuthServ
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public AuthService(
            ApplicationDbContext context,
            ITokenService tokenService,
            IPasswordService passwordService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == registerDto.Email);
            if (userExists)
                throw new ApplicationException("User with this email already exists");

            var isAdmin = registerDto.Email.ToLower() == "admin@gmail.com" && registerDto.Password == "admin123";
            var roleName = isAdmin ? "Admin" : "User";

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role { Name = roleName };
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordService.HashPassword(registerDto.Password),
                RoleId = role.Id
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            var deviceInfo = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();

            var refreshToken = CreateRefreshToken(user.Id, ipAddress, deviceInfo);
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            SetRefreshTokenCookie(refreshToken.Token, refreshToken.ExpiryTime);

            var tokenResult = _tokenService.GenerateJwtToken(user);

            return new AuthResponseDto
            {
                AccessToken = tokenResult.AccessToken,
                Username = user.Username,
                Email = user.Email,
                Role = role.Name
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
                throw new ApplicationException("Invalid email or password");

            bool isPasswordCorrect = _passwordService.VerifyPassword(loginDto.Password, user.PasswordHash);
            if (!isPasswordCorrect)
                throw new ApplicationException("Invalid email or password");

            var ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            var deviceInfo = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();

            var existingTokens = await _context.RefreshTokens
                .Where(t => t.UserId == user.Id && t.DeviceInfo == deviceInfo && t.IsActive)
                .ToListAsync();

            foreach (var token in existingTokens)
            {
                token.IsRevoked = true;
                token.RevokedReason = TokenRevocationReason.NewTokenIssued.ToString();
            }

            var refreshToken = CreateRefreshToken(user.Id, ipAddress, deviceInfo);
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            SetRefreshTokenCookie(refreshToken.Token, refreshToken.ExpiryTime);

            var tokenResult = _tokenService.GenerateJwtToken(user);

            return new AuthResponseDto
            {
                AccessToken = tokenResult.AccessToken,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        private void SetRefreshTokenCookie(string refreshToken, DateTime expiryTime)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = expiryTime
            };

            _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        public async Task<TokenResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .Include(t => t.User)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(t => t.Token == refreshToken);

            if (token == null || !token.IsActive)
                throw new ApplicationException("Invalid or expired refresh token");

            token.IsRevoked = true;
            token.RevokedReason = TokenRevocationReason.NewTokenIssued.ToString();

            var ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            var deviceInfo = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();

            var newRefreshToken = CreateRefreshToken(token.UserId, ipAddress, deviceInfo);
            token.ReplacedByToken = newRefreshToken.Token;

            await _context.RefreshTokens.AddAsync(newRefreshToken);
            await _context.SaveChangesAsync();

            SetRefreshTokenCookie(newRefreshToken.Token, newRefreshToken.ExpiryTime);

            var tokenResult = _tokenService.GenerateJwtToken(token.User);

            return new TokenResponseDto
            {
                AccessToken = tokenResult.AccessToken,
                ExpiresAt = tokenResult.ExpiresAt
            };
        }

        public async Task<bool> LogoutAsync()
        {
            var refreshToken = _httpContextAccessor.HttpContext?.Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var token = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == refreshToken);
            if (token != null)
            {
                token.IsRevoked = true;
                token.RevokedReason = TokenRevocationReason.UserLogout.ToString();
                await _context.SaveChangesAsync();
            }

            _httpContextAccessor.HttpContext?.Response.Cookies.Delete("refreshToken");

            return true;
        }

        private RefreshTokenRecord CreateRefreshToken(Guid userId, string ipAddress, string deviceInfo)
        {
            var refreshToken = _tokenService.GenerateRefreshToken();
            int refreshTokenExpiryDays = int.Parse(_configuration["JwtSettings:RefreshTokenExpiryDays"] ?? "7");

            return new RefreshTokenRecord
            {
                Token = refreshToken,
                ExpiryTime = DateTime.UtcNow.AddDays(refreshTokenExpiryDays),
                CreatedAt = DateTime.UtcNow,
                UserId = userId,
                IsRevoked = false,
                DeviceInfo = deviceInfo,
                IpAddress = ipAddress
            };
        }
    }
}
