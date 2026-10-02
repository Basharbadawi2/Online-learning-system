using Microsoft.IdentityModel.Tokens;
using Online_learning_system.DTOs;
using Online_learning_system.Models;
using Online_learning_system.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_learning_system.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly PasswordResetService _passwordResetService;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration,
            PasswordResetService passwordResetService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordResetService = passwordResetService;
        }

        // =========================
        // REGISTER
        // =========================
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existingUser =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                return "Email already exists.";
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(dto.Password),

                RoleId = 1,
                CreatedAt = DateTime.Now
            };

            await _userRepository.AddUserAsync(user);

            await _userRepository.SaveChangesAsync();

            return "User registered successfully.";
        }

        // =========================
        // LOGIN
        // =========================
        public async Task<object?> LoginAsync(LoginDto dto)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return null;
            }

            bool passwordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!passwordValid)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.UserId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.FullName),

                new Claim(
                    ClaimTypes.Email,
                    user.Email),

                new Claim(
                    ClaimTypes.Role,
                    user.Role.Name)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(
                        _configuration["Jwt:DurationInMinutes"]!)),
                signingCredentials: credentials);

            var tokenString =
                new JwtSecurityTokenHandler()
                    .WriteToken(token);

            return new
            {
                message = "Login successful.",

                token = tokenString,

                user = new
                {
                    user.UserId,
                    user.FullName,
                    user.Email,
                    Role = user.Role.Name
                }
            };
        }

        // =========================
        // FORGOT PASSWORD
        // =========================
        public async Task<string> ForgotPasswordAsync(
            ForgotPasswordDto dto)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return "User not found.";
            }

            var token =
                _passwordResetService.GenerateToken(dto.Email);

            return $"Reset Token: {token}";
        }

        // =========================
        // RESET PASSWORD
        // =========================
        public async Task<string> ResetPasswordAsync(
            ResetPasswordDto dto)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                return "User not found.";
            }

            bool validToken =
                _passwordResetService.ValidateToken(
                    dto.Email,
                    dto.Token);

            if (!validToken)
            {
                return "Invalid token.";
            }

            user.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    dto.NewPassword);

            await _userRepository.SaveChangesAsync();

            _passwordResetService.RemoveToken(dto.Email);

            return "Password reset successfully.";
        }
    }
}