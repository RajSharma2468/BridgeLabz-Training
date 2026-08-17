namespace FundooNotes.Model.Exceptions
{
    // Thrown when a user is not found
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}