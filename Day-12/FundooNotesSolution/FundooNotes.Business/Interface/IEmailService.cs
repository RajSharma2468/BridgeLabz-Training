namespace FundooNotes.Business
{
    // Defines contract for sending emails.
    public interface IEmailService
    {
        // Sends reminder email to user.
        Task SendReminderEmail(
            string toEmail,
            string noteTitle);
    }
}