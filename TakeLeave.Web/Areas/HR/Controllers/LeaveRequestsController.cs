using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.Hr.Mappers;
using TakeLeave.Web.Areas.HR.Models;
using TakeLeave.Web.Areas.User.Mappers;
using TakeLeave.Web.Constants;
using TakeLeave.Web.Mappers;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class LeaveRequestsController : BaseHrController
    {
        private readonly IHrLeaveRequestService _hrLeaveRequestService;
        private readonly IUserLeaveRequestService _userLeaveRequestService;
        private readonly IUserService _userService;

        public LeaveRequestsController(
            IHrLeaveRequestService hrLeaveRequestService,
            IUserLeaveRequestService userLeaveRequestService,
            IUserService userService,
            INotyfService notyfService)
            : base(notyfService)
        {
            _hrLeaveRequestService = hrLeaveRequestService;
            _userLeaveRequestService = userLeaveRequestService;
            _userService = userService;
        }

        public IActionResult GetLeaveRequests()
        {
            List<HrLeaveRequestDTO> leaveRequestDTOs = _hrLeaveRequestService.GetLeaveRequests();

            List<HrLeaveRequestViewModel> hrLeaveRequests = leaveRequestDTOs
                .Select(lr => lr.MapHrLeaveRequestDtoToHrLeaveRequestViewModel())
                .ToList();

            HrLeaveRequestsViewModel hrLeaveRequestsViewModel = new()
            {
                HrLeaveRequests = hrLeaveRequests,
                LoggedInEmployeeId = GetLoggedInEmployeeId(),
            };

            return View(hrLeaveRequestsViewModel);
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult UpdateLeaveRequest(int id)
        {
            HrLeaveRequestDTO hrLeaveRequestDTO = _hrLeaveRequestService.GetLeaveRequestById(id);

            HrLeaveRequestViewModel hrLeaveRequestViewModel = hrLeaveRequestDTO.MapHrLeaveRequestDtoToHrLeaveRequestViewModel();
            hrLeaveRequestViewModel.LeaveTypes = _hrLeaveRequestService.GetLeaveTypes();

            return View(hrLeaveRequestViewModel);
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult UpdateLeaveRequest(HrLeaveRequestViewModel hrLeaveRequestViewModel)
        {
            HrLeaveRequestDTO hrLeaveRequestDTO = hrLeaveRequestViewModel.MapHrLeaveRequestViewModelToHrLeaveRequestDto();

            _hrLeaveRequestService.UpdateLeaveRequest(hrLeaveRequestDTO);

            Notification(NotificationMessageConstants.LeaveRequestEdited, NoticifationTypeConstants.Update);

            return RedirectToAction(nameof(GetLeaveRequests));
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult ApproveLeaveRequest(HrLeaveRequestViewModel hrLeaveRequestViewModel)
        {
            HrLeaveRequestDTO hrLeaveRequestDTO = hrLeaveRequestViewModel.MapHrLeaveRequestViewModelToHrLeaveRequestDto();

            _hrLeaveRequestService.ApproveLeaveRequest(hrLeaveRequestDTO, GetLoggedInEmployeeId());

            return RedirectToAction(nameof(GetLeaveRequests));
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult RejectLeaveRequest(int id)
        {
            _hrLeaveRequestService.RejectLeaveRequest(id, GetLoggedInEmployeeId());

            return RedirectToAction(nameof(GetLeaveRequests));
        }

        public IActionResult CreateLeaveRequest()
        {
            DaysOffDTO? daysOffDTO = _userService.GetUserDetails(GetLoggedInEmployeeId())?.DaysOff;

            LeaveRequestViewModel leaveRequestViewModel = new()
            {
                DaysOff = daysOffDTO.MapDaysOffDtoToDaysOffViewModel()
            };

            return View("~/Areas/User/Views/LeaveRequests/CreateLeaveRequest.cshtml", leaveRequestViewModel);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest(LeaveRequestViewModel leaveRequestViewModel)
        {
            LeaveRequestDTO leaveRequestDTO = leaveRequestViewModel.MapLeaveRequestViewModelToLeaveRequestDto();

            leaveRequestDTO.EmployeeID = GetLoggedInEmployeeId();

            leaveRequestDTO.DaysOff = leaveRequestViewModel.DaysOff.MapDaysOffViewModelToDaysOffDto();

            _userLeaveRequestService.CreateLeaveRequest(leaveRequestDTO);

            return RedirectToAction(nameof(GetLeaveRequests));
        }
    }
}
