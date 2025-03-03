using ApplicationLayer.DTOS;
using ApplicationLayer.InterfaceService;
using DomainLayer.Entity;
using InfrastructureLayer.Data;
using InfrastructureLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext context, IPasswordService passwordService, ITokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto model)
        {
            var existingUser = await _context.Employees.FirstOrDefaultAsync(e => e.Email == model.Email);

            if (existingUser != null)
            {
                return new AuthResponseDto { Message = "User already exists." };
            }

            var user = new Employee
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                PasswordHash = _passwordService.HashPassword(model.Password),
                Role = "Employee"
            };

            await _context.Employees.AddAsync(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto { Message = "User registered successfully." };
        }

        public async Task<AuthResponseDto> LoginUserAsync(LoginDto model)
        {
            var user = await _context.Employees.FirstOrDefaultAsync(e => e.Email == model.Email);
            if (user == null || !_passwordService.VerifyPassword(model.Password, user.PasswordHash))
            {
                return new AuthResponseDto { Message = "Invalid email or password." };
            }

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto { Token = token, Message = "Login successful." };
        }

        public AuthResponseDto LogoutUser()
        {
            return new AuthResponseDto { Message = "User logged out successfully." };
        }
    }
}
