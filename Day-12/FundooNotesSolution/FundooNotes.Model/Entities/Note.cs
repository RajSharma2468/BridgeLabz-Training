namespace FundooNotes.Model.Entities
{
    // Encapsulated Note entity
    public class Note
    {
        private int _noteId;
        private string _title;
        private int _userId;
        private DateTime _createdAt;
        private bool _isTrashed;
        private bool _isArchived;

        public int NoteId
        {
            get { return _noteId; }
            set { _noteId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public bool IsTrashed
        {
            get { return _isTrashed; }
            set { _isTrashed = value; }
        }

        public bool IsArchived
        {
            get { return _isArchived; }
            set { _isArchived = value; }
        }
    }
}