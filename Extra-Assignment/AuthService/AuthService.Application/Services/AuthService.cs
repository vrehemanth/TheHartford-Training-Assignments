using AuthService.Application.Common.Interfaces;
using AuthService.Application.DTOs;
using AuthService.Domain.Entities;
using BCrypt.Net;

namespace AuthService.Application.Services
{
    public class AuthLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthLogic(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate Role
            var validRoles = new[] { "Victim", "Responder", "Hospital" };
            if (!validRoles.Contains(request.Role, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid role. Role must be Victim, Responder, or Hospital.");
            }

            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }

            var token = _jwtProvider.GenerateToken(user);
            return new AuthResponse(token, user.Role);
        }
    }
}
