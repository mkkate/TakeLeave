using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TakeLeave.Business.CustomSettings;
using TakeLeave.Business.Interfaces;

namespace TakeLeave.Business.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ISendGridClient _sendGridClient;

        public EmailSenderService(
            IOptions<EmailSettings> emailSettings,
            ISendGridClient sendGridClient)
        {
            _emailSettings = emailSettings.Value;
            _sendGridClient = sendGridClient;
        }

        public async Task SendEmailToSingleRecipient(string subject, string sendToEmail, string htmlContent)
        {
            var sendFrom = new EmailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
            var message = new SendGridMessage()
            {
                From = sendFrom,
                Subject = subject,
                HtmlContent = htmlContent,
            };
            message.AddTo(sendToEmail);

            var response = await _sendGridClient.SendEmailAsync(message);
        }
    }
}
