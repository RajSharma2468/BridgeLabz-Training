namespace FundooNotes.Model.DTOs.Request
{
    // Data received from client to create a note
    public class CreateNoteRequestDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}