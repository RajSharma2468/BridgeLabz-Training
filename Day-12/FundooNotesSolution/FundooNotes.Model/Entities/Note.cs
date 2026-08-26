namespace FundooNotes.Model.Entities
{
    public class Note
    {
        private int _noteId;
        private string _title;
        private int _userId;
        private DateTime _createdAt;
        private bool _isTrashed;
        private bool _isArchived;
        private bool _isPinned;
        private string? _label;
        private DateTime? _reminderDateTime;
        public int NoteId { get { return _noteId; } set { _noteId = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public int UserId { get { return _userId; } set { _userId = value; } }
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = value; } }
        public bool IsTrashed { get { return _isTrashed; } set { _isTrashed = value; } }
        public bool IsArchived { get { return _isArchived; } set { _isArchived = value; } }
        public bool IsPinned { get { return _isPinned; } set { _isPinned = value; } }
        public string? Label { get { return _label; } set { _label = value; } }
        public DateTime? ReminderDateTime { get { return _reminderDateTime; } set { _reminderDateTime = value; } }
    }
}