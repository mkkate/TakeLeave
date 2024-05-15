using TakeLeave.Business.Helpers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using LeaveRequestType = TakeLeave.Data.Database.LeaveRequests.LeaveRequestType;

namespace TakeLeave.Business.Mappers
{
    public static class HrLeaveRequestMapper
    {
        public static HrLeaveRequestDTO MapLeaveRequestToHrLeaveRequestDto(this LeaveRequest leaveRequest)
        {
            return new()
            {
                Id = leaveRequest.ID,
                FirstName = leaveRequest.RequestedByEmployee.FirstName,
                LastName = leaveRequest.RequestedByEmployee.LastName,
                LeaveStartDate = leaveRequest.LeaveStartDate,
                LeaveEndDate = leaveRequest.LeaveEndDate,
                LeaveType = Enum.GetName(leaveRequest.LeaveType),
                Status = Enum.GetName(leaveRequest.Status),
            };
        }

        public static void MapHrLeaveRequestDtoToLeaveRequest(this HrLeaveRequestDTO hrLeaveRequestDTO, LeaveRequest leaveRequest)
        {
            leaveRequest.ID = hrLeaveRequestDTO.Id;
            leaveRequest.LeaveStartDate = hrLeaveRequestDTO.LeaveStartDate;
            leaveRequest.LeaveEndDate = hrLeaveRequestDTO.LeaveEndDate;
            leaveRequest.LeaveType = (LeaveRequestType)EnumHelper
                .GetEnumValueFromDisplayName<Models.LeaveRequests.LeaveRequestType>(hrLeaveRequestDTO.LeaveType);
        }
    }
}
