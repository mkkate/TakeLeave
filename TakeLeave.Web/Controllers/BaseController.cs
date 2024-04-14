using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TakeLeave.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public int GetLoggedInEmployeeId()
        {
            Int32.TryParse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier), out int employeeId);

            return employeeId;
        }
    }
}
