using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TakeLeave.Business.CustomSettings;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;

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
            SendGridMessage message = EmailHelper.CreateSendGridMessage(
                subject,
                _emailSettings.SenderEmail,
                _emailSettings.SenderName,
                htmlContent);

            message.AddTo(sendToEmail);

            var response = await _sendGridClient.SendEmailAsync(message);
        }

        public async Task SendEmailWithPdf(string subject, string sendToEmail, string htmlContent, EmployeeDTO employeeDTO)
        {
            SendGridMessage message = EmailHelper.CreateSendGridMessage(
                subject,
                _emailSettings.SenderEmail,
                _emailSettings.SenderName,
                htmlContent);

            EmailHelper.AttachPdf(employeeDTO, message);

            message.AddTo(sendToEmail);

            var response = await _sendGridClient.SendEmailAsync(message);
        }

        public async Task SendLeaveRequestEmailWithPdf(string subject, string sendToEmail, string htmlContent, HrLeaveRequestDTO hrLeaveRequestDTO)
        {
            SendGridMessage message = EmailHelper.CreateSendGridMessage(
                subject,
                _emailSettings.SenderEmail,
                _emailSettings.SenderName,
                htmlContent);

            EmailHelper.AttachPdfLeaveRequest(hrLeaveRequestDTO, message);

            message.AddTo(sendToEmail);

            var response = await _sendGridClient.SendEmailAsync(message);
        }
    }
}
