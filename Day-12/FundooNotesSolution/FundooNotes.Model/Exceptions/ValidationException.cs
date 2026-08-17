namespace FundooNotes.Model.Exceptions
{
    // Thrown when business validation fails
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}