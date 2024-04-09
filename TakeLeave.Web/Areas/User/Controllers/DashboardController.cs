using Microsoft.AspNetCore.Mvc;
using TakeLeave.Web.Areas.Constants;

namespace TakeLeave.Web.Areas.User.Controllers
{
    [Area(AreaNames.User)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
