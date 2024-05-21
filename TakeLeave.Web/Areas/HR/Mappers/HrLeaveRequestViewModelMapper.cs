using TakeLeave.Business.Helpers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Web.Areas.HR.Models;
using TakeLeave.Web.Mappers;

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
                DaysOff = leaveRequestDTO.DaysOff.MapDaysOffDtoToDaysOffViewModel(),
                RequestedByEmployeeId = leaveRequestDTO.RequestedByEmployeeID,
            };
        }

        public static HrLeaveRequestDTO MapHrLeaveRequestViewModelToHrLeaveRequestDto(this HrLeaveRequestViewModel leaveRequestViewModel)
        {
            return new()
            {
                Id = leaveRequestViewModel.Id,
                LeaveStartDate = leaveRequestViewModel.LeaveStartDate.ToDateTime(TimeOnly.MinValue),
                LeaveEndDate = leaveRequestViewModel.LeaveEndDate.ToDateTime(TimeOnly.MinValue),
                LeaveType = leaveRequestViewModel.LeaveType,
            };
        }
    }
}
