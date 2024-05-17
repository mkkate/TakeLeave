using Microsoft.IdentityModel.Tokens;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using LeaveRequestStatus = TakeLeave.Data.Database.LeaveRequests.LeaveRequestStatus;
using LeaveRequestType = TakeLeave.Data.Database.LeaveRequests.LeaveRequestType;

namespace TakeLeave.Business.Mappers
{
    public static class LeaveRequestMapper
    {
        public static LeaveRequest MapLeaveRequestDtoToLeaveRequest(this LeaveRequestDTO leaveRequestDTO)
        {
            return new()
            {
                LeaveStartDate = leaveRequestDTO.LeaveStartDate,
                LeaveEndDate = leaveRequestDTO.LeaveEndDate,
                LeaveType = Enum.Parse<LeaveRequestType>(leaveRequestDTO.LeaveType),
                Comment = leaveRequestDTO.Comment,
                EmployeeID = leaveRequestDTO.EmployeeID,
                Status = leaveRequestDTO.Status.IsNullOrEmpty() ? LeaveRequestStatus.OnWait : Enum.Parse<LeaveRequestStatus>(leaveRequestDTO.Status),
            };
        }

        public static LeaveRequestDTO MapLeaveRequestToLeaveRequestDto(this LeaveRequest leaveRequest)
        {
            LeaveRequestDTO leaveRequestDTO = new()
            {
                LeaveStartDate = leaveRequest.LeaveStartDate,
                LeaveEndDate = leaveRequest.LeaveEndDate,
                LeaveType = Enum.GetName(leaveRequest.LeaveType),
                Comment = leaveRequest.Comment,
                EmployeeID = leaveRequest.EmployeeID,
                Status = Enum.GetName(leaveRequest.Status),
            };

            if (leaveRequest.HandledByHr is null)
            {
                leaveRequestDTO.HandledByHrID = 0;
                leaveRequestDTO.HrFirstName = string.Empty;
                leaveRequestDTO.HrLastName = string.Empty;
            }
            else
            {
                leaveRequestDTO.HandledByHrID = leaveRequest.HandledByHrID;
                leaveRequestDTO.HrFirstName = leaveRequest.HandledByHr.FirstName;
                leaveRequestDTO.HrLastName = leaveRequest.HandledByHr.LastName;
            }

            return leaveRequestDTO;
        }
    }
}
