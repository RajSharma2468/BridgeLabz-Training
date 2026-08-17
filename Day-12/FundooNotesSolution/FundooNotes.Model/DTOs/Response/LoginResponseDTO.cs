namespace FundooNotes.Model.DTOs.Response
{
    // Data sent back to client after successful login
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}