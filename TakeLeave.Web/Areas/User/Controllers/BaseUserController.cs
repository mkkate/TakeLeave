using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Areas.Constants;
using TakeLeave.Web.Controllers;

namespace TakeLeave.Web.Areas.User.Controllers
{
    [Area(AreaNames.User)]
    [Authorize(Roles = EmployeeRoles.User)]
    public class BaseUserController : BaseController
    {

    }
}
