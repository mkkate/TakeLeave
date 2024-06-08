using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.User.Mappers;
using TakeLeave.Web.Areas.User.Models;

namespace TakeLeave.Web.Areas.User.Controllers
{
    public class DashboardController : BaseUserController
    {
        private readonly IUserService _userService;

        public DashboardController(
            IUserService userService,
            INotyfService notyfService)
            : base(notyfService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            UserDTO? userDTO = _userService.GetUserDetails(GetLoggedInEmployeeId());

            if (userDTO == null)
            {
                return NotFound();
            }
            else
            {
                UserViewModel userViewModel = userDTO.MapUserDtoToUserViewModel();

                return View(userViewModel);
            }
        }
    }
}
