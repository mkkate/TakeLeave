using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.Constants;
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
            UserViewModel userViewModel = new UserViewModel();

            UserDTO userDTO = _userService.GetUserDetails(GetLoggedInEmployeeId());

            userViewModel.FirstName = userDTO.FirstName;
            userViewModel.LastName = userDTO.LastName;
            userViewModel.Address = userDTO.Address;
            userViewModel.EmploymentStartDate = userDTO.EmploymentStartDate;
            userViewModel.EmploymentEndDate = userDTO.EmploymentEndDate;

            userViewModel.DaysOff.Vacation = userDTO.DaysOff.Vacation;
            userViewModel.DaysOff.Paid = userDTO.DaysOff.Paid;
            userViewModel.DaysOff.Unpaid = userDTO.DaysOff.Unpaid;
            userViewModel.DaysOff.SickLeave = userDTO.DaysOff.SickLeave;

            userViewModel.Position.Title = userDTO.Position.Title;
            userViewModel.Position.Description = userDTO.Position.Description;
            userViewModel.Position.SeniorityLevel = userDTO.Position.SeniorityLevel;

            return View(userViewModel);
        }
    }
}
