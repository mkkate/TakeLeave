using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;

namespace TakeLeave.Business.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailToSingleRecipient(string subject, string sendToEmail, string htmlContent);
        Task SendEmailWithPdf(string subject, string sendToEmail, string htmlContent, EmployeeDTO employeeDTO);
        Task SendLeaveRequestEmailWithPdf(string subject, string sendToEmail, string htmlContent, HrLeaveRequestDTO hrLeaveRequestDTO);
    }
}
