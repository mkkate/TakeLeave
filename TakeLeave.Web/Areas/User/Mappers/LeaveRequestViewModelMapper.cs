using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.Mappers
{
    public static class LeaveRequestViewModelMapper
    {
        public static LeaveRequestDTO MapLeaveRequestViewModelToLeaveRequestDto(this LeaveRequestViewModel leaveRequestViewModel)
        {
            return new()
            {
                LeaveStartDate = leaveRequestViewModel.LeaveStartDate,
                LeaveEndDate = leaveRequestViewModel.LeaveEndDate,
                LeaveType = leaveRequestViewModel.LeaveType,
                Comment = leaveRequestViewModel.Comment,
            };
        }
    }
}
