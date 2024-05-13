using Microsoft.AspNetCore.Mvc;
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
    }
}
