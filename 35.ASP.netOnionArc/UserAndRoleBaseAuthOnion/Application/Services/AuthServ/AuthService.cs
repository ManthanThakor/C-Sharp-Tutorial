using Application.DTO;
using Application.Services.PasswordService;
using Application.Services.TokenService;
using Application.Services.UserSer;
using Domain.Entity;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthServ
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public AuthService(ApplicationDbContext context, ITokenService tokenService, IPasswordService passwordService)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                throw new ApplicationException("User with this email already exists");

            var isAdmin = registerDto.Email.ToLower() == "admin@gmail.com" && registerDto.Password == "admin123";
            var roleName = isAdmin ? "Admin" : "User";
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName)
                       ?? throw new ApplicationException("Role not found");

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordService.HashPassword(registerDto.Password), // Use PasswordService
                RoleId = role.Id,
                RefreshToken = _tokenService.GenerateRefreshToken(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7)
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(user),
                Username = user.Username,
                Email = user.Email,
                Role = role.Name
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == loginDto.Email)
                      ?? throw new ApplicationException("Invalid email or password");

            if (!_passwordService.VerifyPassword(loginDto.Password, user.PasswordHash))
                throw new ApplicationException("Invalid email or password");

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(user),
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.Name
            };
        }
        public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
        {
            var user = await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new ApplicationException("Invalid refresh token");

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(user),
                Username = user.Username,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null)
                return false;

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _context.SaveChangesAsync();
            return true;
        }

    }

}