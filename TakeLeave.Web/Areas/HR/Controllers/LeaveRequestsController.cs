using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.Hr.Mappers;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class LeaveRequestsController : BaseHrController
    {
        private readonly IHrLeaveRequestService _hrLeaveRequestService;

        public LeaveRequestsController(IHrLeaveRequestService hrLeaveRequestService)
        {
            _hrLeaveRequestService = hrLeaveRequestService;
        }

        public IActionResult GetLeaveRequests()
        {
            List<HrLeaveRequestDTO> leaveRequestDTOs = _hrLeaveRequestService.GetLeaveRequests();

            List<HrLeaveRequestViewModel> hrLeaveRequestViewModels = leaveRequestDTOs
                .Select(lr => lr.MapHrLeaveRequestDtoToHrLeaveRequestViewModel())
                .ToList();

            return View(hrLeaveRequestViewModels);
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
    }
}
