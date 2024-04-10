using Microsoft.AspNetCore.Mvc;
using TakeLeave.Web.Areas.Constants;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    [Area(AreaNames.HR)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
