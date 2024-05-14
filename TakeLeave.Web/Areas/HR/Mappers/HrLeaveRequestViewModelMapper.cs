using TakeLeave.Business.Helpers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.Hr.Mappers
{
    public static class HrLeaveRequestViewModelMapper
    {
        public static HrLeaveRequestViewModel MapHrLeaveRequestDtoToHrLeaveRequestViewModel(this HrLeaveRequestDTO leaveRequestDTO)
        {
            LeaveRequestType leaveRequestType = Enum.Parse<LeaveRequestType>(leaveRequestDTO.LeaveType);
            LeaveRequestStatus leaveRequestStatus = Enum.Parse<LeaveRequestStatus>(leaveRequestDTO.Status);

            return new()
            {
                Id = leaveRequestDTO.Id,
                FirstName = leaveRequestDTO.FirstName,
                LastName = leaveRequestDTO.LastName,
                LeaveStartDate = DateOnly.FromDateTime(leaveRequestDTO.LeaveStartDate),
                LeaveEndDate = DateOnly.FromDateTime(leaveRequestDTO.LeaveEndDate),
                LeaveType = leaveRequestType.GetEnumDescription(),
                Status = leaveRequestStatus.GetEnumDescription(),
                Comment = leaveRequestDTO.Comment,
            };
        }
    }
}
