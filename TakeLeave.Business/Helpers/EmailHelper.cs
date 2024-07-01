using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using SendGrid.Helpers.Mail;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;

namespace TakeLeave.Business.Helpers
{
    public static class EmailHelper
    {
        public static SendGridMessage CreateSendGridMessage(string subject, string senderEmail, string senderName, string htmlContent)
        {
            var sendFrom = new EmailAddress(senderEmail, senderName);
            var message = new SendGridMessage()
            {
                From = sendFrom,
                Subject = subject,
                //HtmlContent = htmlContent,
                PlainTextContent = htmlContent,
            };

            return message;
        }
        public static void AttachPdf(EmployeeDTO employeeDTO, SendGridMessage message)
        {
            var htmlTemplate = File.ReadAllText("EmailTemplates/EmployeeCreated.html");
            htmlTemplate = htmlTemplate.Replace("{firstName}", employeeDTO.FirstName)
                .Replace("{lastName}", employeeDTO.LastName)
                .Replace("{username}", employeeDTO.UserName)
                .Replace("{email}", employeeDTO.Email)
                .Replace("{address}", employeeDTO.Address)
                .Replace("{idNumber}", employeeDTO.IDNumber)
                .Replace("{password}", employeeDTO.Password)
                .Replace("{startDate}", employeeDTO.EmploymentStartDate.ToString("dd-MM-yyyy"))
                .Replace("{endDate}", employeeDTO.EmploymentEndDate?.ToString("dd-MM-yyyy"))
                .Replace("{seniority}", employeeDTO.Position.SeniorityLevel)
                .Replace("{title}", employeeDTO.Position.Title)
                .Replace("{vacation}", employeeDTO.DaysOff.Vacation.ToString())
                .Replace("{unpaid}", employeeDTO.DaysOff.Unpaid.ToString())
                .Replace("{paid}", employeeDTO.DaysOff.Paid.ToString())
                .Replace("{sickLeave}", employeeDTO.DaysOff.SickLeave.ToString());

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter pdfWriter = new PdfWriter(ms);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                Document document = new Document(pdfDocument);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlTemplate, pdfDocument, converterProperties);

                pdfDocument.Close();

                message.AddAttachment("report",
                    Convert.ToBase64String(ms.ToArray()),
                    "application/pdf");
            }
        }

        public static void AttachPdfLeaveRequest(HrLeaveRequestDTO hrLeaveRequestDTO, SendGridMessage message)
        {
            var htmlTemplate = File.ReadAllText("EmailTemplates/LeaveRequestHandled.html");
            htmlTemplate = htmlTemplate.Replace("{firstName}", hrLeaveRequestDTO.FirstName)
                .Replace("{requestAction}", hrLeaveRequestDTO.Status)
                .Replace("{leaveType}", hrLeaveRequestDTO.LeaveType)
                .Replace("{leaveStartDate}", hrLeaveRequestDTO.LeaveStartDate.ToString("dd-MM-yyyy"))
                .Replace("{leaveEndDate}", hrLeaveRequestDTO.LeaveEndDate.ToString("dd-MM-yyyy"))
                .Replace("{leaveStatus}", hrLeaveRequestDTO.Status)
                .Replace("{vacation}", hrLeaveRequestDTO.DaysOff.Vacation.ToString())
                .Replace("{unpaid}", hrLeaveRequestDTO.DaysOff.Unpaid.ToString())
                .Replace("{paid}", hrLeaveRequestDTO.DaysOff.Paid.ToString())
                .Replace("{sickLeave}", hrLeaveRequestDTO.DaysOff.SickLeave.ToString());

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter pdfWriter = new PdfWriter(ms);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                Document document = new Document(pdfDocument);

                ConverterProperties converterProperties = new ConverterProperties();
                HtmlConverter.ConvertToPdf(htmlTemplate, pdfDocument, converterProperties);

                pdfDocument.Close();

                message.AddAttachment("Leave request report",
                    Convert.ToBase64String(ms.ToArray()),
                    "application/pdf");
            }
        }
    }
}
