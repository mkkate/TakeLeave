namespace TakeLeave.Business.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailToSingleRecipient(string subject, string sendToEmail, string htmlContent);
    }
}
