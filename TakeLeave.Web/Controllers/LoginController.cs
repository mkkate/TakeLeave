using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Web.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TakeLeave.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Employee> _signInManager;
        private readonly UserManager<Employee> _userManager;

        public LoginController(SignInManager<Employee> signInManager, UserManager<Employee> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                SignInResult? result = await _signInManager.PasswordSignInAsync(
                    loginViewModel.Input.UserName,
                    loginViewModel.Input.Password,
                    isPersistent: false,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    Employee? employee = await _userManager.FindByNameAsync(loginViewModel.Input.UserName);

                    if (employee != null)
                    {
                        bool userRole = await _userManager.IsInRoleAsync(employee, "User");

                        return userRole ? RedirectToAction("Index", "User") : RedirectToAction("Index", "Hr");
                    }
                }
            }

            return View(loginViewModel);
        }
    }
}
