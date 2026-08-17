using Microsoft.AspNetCore.Mvc;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;
using FundooNotes.Model.Exceptions;
using FundooNotes.Business;

namespace FundooNotes.API.Controllers
{
    // Handles user management HTTP requests
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _business;

        public UserController(IUserBusiness business)
        {
            _business = business;
        }

        // POST api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDTO dto)
        {
            try
            {
                _business.Register(dto);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "User registered successfully.",
                    Data = null
                };
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        // POST api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            try
            {
                LoginResponseDTO loginData = _business.Login(dto);

                var response = new ResponseDTO<LoginResponseDTO>
                {
                    Success = true,
                    Message = "Login successful.",
                    Data = loginData
                };
                return Ok(response);
            }
            catch (UnauthorizedException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return Unauthorized(response);
            }
        }

        // POST api/user/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDTO dto)
        {
            try
            {
                await _business.ForgotPassword(dto);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Password reset instructions sent.",
                    Data = null
                };
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return NotFound(response);
            }
        }

        // PUT api/user/reset-password
        [HttpPut("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequestDTO dto)
        {
            try
            {
                _business.ResetPassword(dto);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Password reset successfully.",
                    Data = null
                };
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }
    }
}