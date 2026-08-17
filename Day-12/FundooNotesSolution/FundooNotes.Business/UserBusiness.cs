using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net.Http.Json;
using FundooNotes.Model.Entities;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;
using FundooNotes.Model.Exceptions;
using FundooNotes.Repository;

namespace FundooNotes.Business
{
    // Handles user business logic including auth
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _repository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _jwtSecret = "ThisIsMySecretKeyForFundooNotesApp12345";

        public UserBusiness(IUserRepository repository, IHttpClientFactory httpClientFactory)
        {
            _repository = repository;
            _httpClientFactory = httpClientFactory;
        }

        // Registers new user with hashed password
        public void Register(RegisterRequestDTO dto)
        {
            var existing = _repository.GetByEmail(dto.Email);
            if (existing != null)
                throw new ValidationException("Email already registered.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            User user = new User();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = hashedPassword;

            _repository.Add(user);
        }

        // Validates credentials and returns login response with token
        public LoginResponseDTO Login(LoginRequestDTO dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if (user == null)
                throw new UnauthorizedException("Invalid email or password.");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isValid)
                throw new UnauthorizedException("Invalid email or password.");

            string token = GenerateJwtToken(user);

            LoginResponseDTO response = new LoginResponseDTO();
            response.Token = token;
            response.Name = user.Name;
            response.Email = user.Email;

            return response;
        }

        // Generates reset token and demonstrates HttpClient external call
        public async Task ForgotPassword(ForgotPasswordRequestDTO dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if (user == null)
                throw new UserNotFoundException("Email not found.");

            string token = Guid.NewGuid().ToString();
            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            _repository.Update(user);

            var client = _httpClientFactory.CreateClient();
            var payload = new
            {
                to = user.Email,
                subject = "Password Reset Request",
                resetToken = token
            };

            try
            {
                await client.PostAsJsonAsync("https://httpbin.org/post", payload);
            }
            catch
            {
                // Email service failure should not block token generation
            }
        }

        // Validates token and updates password
        public void ResetPassword(ResetPasswordRequestDTO dto)
        {
            var user = _repository.GetByResetToken(dto.Token);
            if (user == null)
                throw new ValidationException("Invalid or expired reset token.");

            if (user.ResetTokenExpiry < DateTime.UtcNow)
                throw new ValidationException("Reset token has expired.");

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            _repository.Update(user);
        }

        // Creates a signed JWT token for the user
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "FundooNotesApp",
                audience: "FundooNotesApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}