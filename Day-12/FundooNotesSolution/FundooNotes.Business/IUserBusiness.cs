using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;

namespace FundooNotes.Business
{
    // Defines business operations contract
    public interface IUserBusiness
    {
        void Register(RegisterRequestDTO dto);
        LoginResponseDTO Login(LoginRequestDTO dto);
        Task ForgotPassword(ForgotPasswordRequestDTO dto);
        void ResetPassword(ResetPasswordRequestDTO dto);
    }
}