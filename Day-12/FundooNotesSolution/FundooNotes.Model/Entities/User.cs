namespace FundooNotes.Model.Entities
{
    // Encapsulated User entity
    public class User
    {
        private int _userId;
        private string _name;
        private string _email;
        private string _password;
        private string? _resetToken;              
        private DateTime? _resetTokenExpiry;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string? ResetToken                  
        {
            get { return _resetToken; }
            set { _resetToken = value; }
        }

        public DateTime? ResetTokenExpiry
        {
            get { return _resetTokenExpiry; }
            set { _resetTokenExpiry = value; }
        }
    }
}