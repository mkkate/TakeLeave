using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TakeLeave.Web.Constants;

namespace TakeLeave.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly INotyfService _notyfService;

        public BaseController(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }

        public int GetLoggedInEmployeeId()
        {
            Int32.TryParse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out int employeeId);

            return employeeId;
        }

        public void Notification(string message, string type)
        {
            switch (type)
            {
                case NotificationTypeConstants.Success or
                NotificationTypeConstants.Create or
                NotificationTypeConstants.Approve:
                    _notyfService.Success(message);
                    break;

                case NotificationTypeConstants.Info or
                NotificationTypeConstants.Update:
                    _notyfService.Information(message);
                    break;

                case NotificationTypeConstants.Warning:
                    _notyfService.Warning(message);
                    break;

                case NotificationTypeConstants.Error or
                NotificationTypeConstants.Delete or
                NotificationTypeConstants.Reject:
                    _notyfService.Error(message);
                    break;
            }
        }
    }
}
