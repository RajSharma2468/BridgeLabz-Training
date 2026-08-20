namespace FundooNotes.Model.DTOs.Response
{
    // Data sent back to client for a note
    public class NoteResponseDTO
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsTrashed { get; set; }
        public bool IsArchived { get; set; }
    }
}