using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailToSingleRecipient(string subject, string sendToEmail, string htmlContent);
        Task SendEmailWithPdf(string subject, string sendToEmail, string htmlContent, EmployeeDTO employeeDTO);
    }
}
