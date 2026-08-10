namespace ContactApp.Model
{
    // Encapsulated Contact model
    public class Contact
    {
        private int _contactId;
        private string _name;
        private string _phone;
        private string _email;

        public int ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}