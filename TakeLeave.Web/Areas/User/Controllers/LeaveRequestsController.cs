using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.User.Mappers;
using TakeLeave.Web.Mappers;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.Controllers
{
    public class LeaveRequestsController : BaseUserController
    {
        private readonly IUserLeaveRequestService _userLeaveRequestService;
        private readonly IUserService _userService;

        public LeaveRequestsController(
            IUserLeaveRequestService userLeaveRequestService,
            IUserService userService,
            INotyfService notyfService)
            : base(notyfService)
        {
            _userLeaveRequestService = userLeaveRequestService;
            _userService = userService;
        }

        public IActionResult CreateLeaveRequest()
        {
            DaysOffDTO? daysOffDTO = _userService.GetUserDetails(GetLoggedInEmployeeId())?.DaysOff;

            LeaveRequestViewModel leaveRequestViewModel = new()
            {
                DaysOff = daysOffDTO.MapDaysOffDtoToDaysOffViewModel()
            };

            return View(leaveRequestViewModel);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest(LeaveRequestViewModel leaveRequestViewModel)
        {
            LeaveRequestDTO leaveRequestDTO = leaveRequestViewModel.MapLeaveRequestViewModelToLeaveRequestDto();

            leaveRequestDTO.EmployeeID = GetLoggedInEmployeeId();

            leaveRequestDTO.DaysOff = leaveRequestViewModel.DaysOff.MapDaysOffViewModelToDaysOffDto();

            _userLeaveRequestService.CreateLeaveRequest(leaveRequestDTO);

            return RedirectToAction(nameof(LeaveRequestsList));
        }

        public IActionResult LeaveRequestsList()
        {
            List<LeaveRequestDTO> leaveRequestDTOs = _userLeaveRequestService.GetLeaveRequestsForLoggedInUser(GetLoggedInEmployeeId());

            List<LeaveRequestViewModel> leaveRequestViewModels = leaveRequestDTOs
                .Select(leaveDTO => leaveDTO.MapLeaveRequestDtoToLeaveRequestViewModel())
                .ToList();

            return View(leaveRequestViewModels);
        }
    }
}
