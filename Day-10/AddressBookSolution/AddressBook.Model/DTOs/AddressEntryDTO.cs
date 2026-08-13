namespace AddressBook.Model.DTOs
{
    // Data transfer object used for API requests and responses
    public class AddressEntryDTO
    {
        private string _name;
        private string _phone;
        private string _email;
        private string _address;

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

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}