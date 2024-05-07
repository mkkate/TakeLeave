using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.Constants;
using TakeLeave.Web.Areas.User.Mappers;
using TakeLeave.Web.Controllers;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.Controllers
{
    [Area(AreaNames.User)]
    public class LeaveRequestsController : BaseController
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IUserService _userService;

        public LeaveRequestsController(
            ILeaveRequestService leaveRequestService,
            IUserService userService)
        {
            _leaveRequestService = leaveRequestService;
            _userService = userService;
        }

        public IActionResult CreateLeaveRequest()
        {
            DaysOffDTO? daysOffDTO = _userService.GetUserDetails(GetLoggedInEmployeeId())?.DaysOff;

            LeaveRequestViewModel leaveRequestViewModel = new();

            leaveRequestViewModel.DaysOff.Vacation = daysOffDTO.Vacation;
            leaveRequestViewModel.DaysOff.Paid = daysOffDTO.Paid;
            leaveRequestViewModel.DaysOff.Unpaid = daysOffDTO.Unpaid;
            leaveRequestViewModel.DaysOff.SickLeave = daysOffDTO.SickLeave;

            return View(leaveRequestViewModel);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest(LeaveRequestViewModel leaveRequestViewModel)
        {
            LeaveRequestDTO leaveRequestDTO = leaveRequestViewModel.MapLeaveRequestViewModelToLeaveRequestDto();

            leaveRequestDTO.EmployeeID = GetLoggedInEmployeeId();

            leaveRequestDTO.DaysOff.Vacation = leaveRequestViewModel.DaysOff.Vacation;
            leaveRequestDTO.DaysOff.Paid = leaveRequestViewModel.DaysOff.Paid;
            leaveRequestDTO.DaysOff.Unpaid = leaveRequestViewModel.DaysOff.Unpaid;
            leaveRequestDTO.DaysOff.SickLeave = leaveRequestViewModel.DaysOff.SickLeave;

            _leaveRequestService.CreateLeaveRequest(leaveRequestDTO);

            return View(leaveRequestViewModel);
        }
    }
}
