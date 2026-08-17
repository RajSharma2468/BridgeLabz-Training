namespace FundooNotes.Model.DTOs.Request
{
    // Data received from client for reset password
    public class ResetPasswordRequestDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}