using Microsoft.AspNetCore.Mvc;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class DashboardController : BaseHrController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
