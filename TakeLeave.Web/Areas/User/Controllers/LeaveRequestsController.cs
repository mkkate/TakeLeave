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

            _leaveRequestService.CreateLeaveRequest(leaveRequestDTO);

            return View(leaveRequestViewModel);
        }

        public IActionResult LeaveRequestsList()
        {
            List<LeaveRequestDTO> leaveRequestDTOs = _leaveRequestService.GetLeaveRequestsForLoggedInUser(GetLoggedInEmployeeId());

            List<LeaveRequestViewModel> leaveRequestViewModels = leaveRequestDTOs
                .Select(leaveDTO => leaveDTO.MapLeaveRequestDtoToLeaveRequestViewModel())
                .ToList();

            return View(leaveRequestViewModels);
        }
    }
}
