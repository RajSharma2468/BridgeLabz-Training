namespace FundooNotes.Model.DTOs.Request
{
    // Data received from client for registration
    public class RegisterRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}