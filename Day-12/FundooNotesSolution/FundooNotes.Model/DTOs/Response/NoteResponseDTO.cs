namespace FundooNotes.Model.DTOs.Response
{
    // Data returned to the client for a note.
    public class NoteResponseDTO
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsTrashed { get; set; }

        public bool IsArchived { get; set; }

        // Label of the note.
        public string? Label { get; set; }

        // Reminder date and time.
        public DateTime? ReminderDateTime { get; set; }
    }
}