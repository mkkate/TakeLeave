using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Web.Constants;

namespace TakeLeave.Web.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<Employee> _signInManager;

        public LogoutController(SignInManager<Employee> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnLogout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(ControllerActionConstants.OnLogin, ControllerNameConstants.Login);
        }
    }
}
