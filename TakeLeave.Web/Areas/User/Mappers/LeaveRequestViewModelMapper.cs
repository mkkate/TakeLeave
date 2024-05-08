using TakeLeave.Business.Helpers;
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

        public static LeaveRequestViewModel MapLeaveRequestDtoToLeaveRequestViewModel(this LeaveRequestDTO leaveRequestDTO)
        {
            LeaveRequestType leaveRequestType = Enum.Parse<LeaveRequestType>(leaveRequestDTO.LeaveType);
            LeaveRequestStatus leaveRequestStatus = Enum.Parse<LeaveRequestStatus>(leaveRequestDTO.Status);

            return new()
            {
                LeaveStartDate = leaveRequestDTO.LeaveStartDate,
                LeaveEndDate = leaveRequestDTO.LeaveEndDate,
                LeaveType = leaveRequestType.GetEnumDescription(),
                Status = leaveRequestStatus.GetEnumDescription(),
                Comment = leaveRequestDTO.Comment,
            };
        }
    }
}
