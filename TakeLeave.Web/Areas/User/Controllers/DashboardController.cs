using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.Constants;
using TakeLeave.Web.Areas.User.Mappers;
using TakeLeave.Web.Areas.User.Models;
using TakeLeave.Web.Controllers;

namespace TakeLeave.Web.Areas.User.Controllers
{
    [Area(AreaNames.User)]
    [Authorize(Roles = EmployeeRoles.User)]
    public class DashboardController : BaseController
    {
        private readonly IUserService _userService;

        public DashboardController(IUserService userService)
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
