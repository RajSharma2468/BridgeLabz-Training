using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace FundooNotes.Business
{
    // This class sends reminder emails using SMTP.
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        // Configuration is injected through constructor.
        public EmailService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Sends reminder email.
        public async Task SendReminderEmail(
            string toEmail,
            string noteTitle)
        {
            // Read SMTP settings from appsettings.json.
            var smtpHost =
                _configuration[
                    "SmtpSettings:Host"];

            var smtpPort =
                int.Parse(
                    _configuration[
                        "SmtpSettings:Port"]);

            var senderEmail =
                _configuration[
                    "SmtpSettings:SenderEmail"];

            var senderPassword =
                _configuration[
                    "SmtpSettings:SenderPassword"];

            var senderName =
                _configuration[
                    "SmtpSettings:SenderName"];

            // Create email message.
            var message = new MimeMessage();

            // Sender address.
            message.From.Add(
                new MailboxAddress(
                    senderName,
                    senderEmail));

            // Receiver address.
            message.To.Add(
                new MailboxAddress(
                    "",
                    toEmail));

            // Email subject.
            message.Subject =
                "Reminder: " + noteTitle;

            // Email body.
            message.Body =
                new TextPart("plain")
                {
                    Text =
                        $"This is a reminder for your note: {noteTitle}"
                };

            // Create SMTP client.
            using (var client =
                   new SmtpClient())
            {
                // Connect to Gmail SMTP server.
                await client.ConnectAsync(
                    smtpHost,
                    smtpPort,
                    MailKit.Security
                        .SecureSocketOptions
                        .StartTls);

                // Authenticate sender.
                await client.AuthenticateAsync(
                    senderEmail,
                    senderPassword);

                // Send email.
                await client.SendAsync(message);

                // Disconnect from SMTP server.
                await client.DisconnectAsync(true);
            }
        }
    }
}