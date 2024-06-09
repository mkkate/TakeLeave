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
                case NoticifationTypeConstants.Success or
                NoticifationTypeConstants.Create or
                NoticifationTypeConstants.Approve:
                    _notyfService.Success(message);
                    break;

                case NoticifationTypeConstants.Info or NoticifationTypeConstants.Update:
                    _notyfService.Information(message);
                    break;

                case NoticifationTypeConstants.Warning:
                    _notyfService.Warning(message);
                    break;

                case NoticifationTypeConstants.Error or NoticifationTypeConstants.Delete:
                    _notyfService.Error(message);
                    break;
            }
        }
    }
}
