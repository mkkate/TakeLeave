using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Areas.Constants;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IndexPageByRole()
        {
            if (User.Identity?.IsAuthenticated is true)
            {
                return User.IsInRole(EmployeeRoles.User) ?
                    RedirectToAction("Index", "Dashboard", new { area = AreaNames.User }) :
                    RedirectToAction("Index", "Dashboard", new { area = AreaNames.HR });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
