namespace FundooNotes.Model.DTOs.Request
{
    // Data received from client for login
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}