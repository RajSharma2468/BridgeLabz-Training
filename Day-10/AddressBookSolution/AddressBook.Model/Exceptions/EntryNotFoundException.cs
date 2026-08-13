namespace AddressBook.Model.Exceptions
{
    // Thrown when an address entry is not found
    public class EntryNotFoundException : Exception
    {
        public EntryNotFoundException(string message) : base(message)
        {
        }
    }
}