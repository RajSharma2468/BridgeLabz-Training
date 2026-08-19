namespace FundooNotes.Model.Entities
{
    // Encapsulated Note entity
    public class Note
    {
        private int _noteId;
        private string _title;
        private string? _description;
        private int _userId;
        private DateTime _createdAt;

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

        public string? Description
        {
            get { return _description; }
            set { _description = value; }
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
    }
}