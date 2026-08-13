using System.ComponentModel.DataAnnotations;

namespace AddressBook.Model.Entities
{
    // Encapsulated AddressEntry entity (matches DB table)
    public class AddressEntry
    {
        private int _entryId;
        private string _name;
        private string _phone;
        private string _email;
        private string _address;

        [Key]
        public int EntryId
        {
            get { return _entryId; }
            set { _entryId = value; }
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

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}