using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;

namespace TakeLeave.Business.Mappers
{
    public static class HrLeaveRequestMapper
    {
        public static HrLeaveRequestDTO MapLeaveRequestToHrLeaveRequestDto(this LeaveRequest leaveRequest)
        {
            return new()
            {
                FirstName = leaveRequest.RequestedByEmployee.FirstName,
                LastName = leaveRequest.RequestedByEmployee.LastName,
                LeaveStartDate = leaveRequest.LeaveStartDate,
                LeaveEndDate = leaveRequest.LeaveEndDate,
                LeaveType = Enum.GetName(leaveRequest.LeaveType),
                Comment = leaveRequest.Comment,
                EmployeeID = leaveRequest.EmployeeID,
                Status = Enum.GetName(leaveRequest.Status),
            };
        }
    }
}
