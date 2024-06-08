using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Areas.Constants;
using TakeLeave.Web.Controllers;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    [Area(AreaNames.HR)]
    [Authorize(Roles = EmployeeRoles.AdminOrHR)]
    public class BaseHrController : BaseController
    {
        public BaseHrController(INotyfService notyfService) : base(notyfService)
        {
        }
    }
}
