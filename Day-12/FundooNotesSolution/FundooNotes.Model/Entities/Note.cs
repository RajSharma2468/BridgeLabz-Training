namespace FundooNotes.Model.Entities
{
    // This class represents the Note table in the database.
    public class Note
    {
        private int _noteId;
        private string _title;
        private int _userId;
        private DateTime _createdAt;
        private bool _isTrashed;
        private bool _isArchived;
        private string? _label;

        // Primary key of the note.
        public int NoteId
        {
            get { return _noteId; }
            set { _noteId = value; }
        }

        // Title of the note.
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        // User who owns the note.
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        // Date and time when note was created.
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        // Indicates whether note is moved to trash.
        public bool IsTrashed
        {
            get { return _isTrashed; }
            set { _isTrashed = value; }
        }

        // Indicates whether note is archived.
        public bool IsArchived
        {
            get { return _isArchived; }
            set { _isArchived = value; }
        }

        // Label assigned to the note.
        public string? Label
        {
            get { return _label; }
            set { _label = value; }
        }

        
        public DateTime? ReminderDateTime { get; set; }
    }
}