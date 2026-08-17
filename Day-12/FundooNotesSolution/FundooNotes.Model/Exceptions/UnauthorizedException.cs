namespace FundooNotes.Model.Exceptions
{
    // Thrown when authentication fails
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}