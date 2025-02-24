using Application.DTO;
using Application.Services.PasswordService;
using Application.Services.TokenService;
using Application.Services.UserSer;
using Domain.Entity;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
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
            // Check if user exists
            var userExists = await _context.Users.AnyAsync(u => u.Email == registerDto.Email);
            if (userExists)
                throw new ApplicationException("User with this email already exists");

            // Determine role
            var isAdmin = registerDto.Email.ToLower() == "admin@gmail.com" && registerDto.Password == "admin123";
            var roleName = isAdmin ? "Admin" : "User";

            // Ensure role exists
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
            {
                role = new Role { Name = roleName };
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
            }

            // Create user
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordService.HashPassword(registerDto.Password),
                RoleId = role.Id,
                RefreshToken = _tokenService.GenerateRefreshToken(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7)
            };

            Console.WriteLine($"[Register] Created user with email: {user.Email} and hash: {user.PasswordHash.Substring(0, 10)}...");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(user),
                RefreshToken = user.RefreshToken,
                Username = user.Username,
                Email = user.Email,
                Role = role.Name
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            Console.WriteLine($"[Login] Attempting login for email: {loginDto.Email}");

            var user = await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
            {
                Console.WriteLine($"[Login] No user found with email: {loginDto.Email}");
                throw new ApplicationException("Invalid email or password");
            }

            bool isPasswordCorrect = _passwordService.VerifyPassword(loginDto.Password, user.PasswordHash);
            if (!isPasswordCorrect)
            {
                Console.WriteLine($"[Login] Password mismatch for user: {loginDto.Email}");
                throw new ApplicationException("Invalid email or password");
            }

            // Generate new refresh token
            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = _tokenService.GenerateJwtToken(user),
                RefreshToken = user.RefreshToken,
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
