using TakeLeave.Business.Models;
using TakeLeave.Data.Database.LeaveRequests;

namespace TakeLeave.Business.Mappers
{
    public static class CalendarMapper
    {
        public static CalendarDTO MapLeaveRequestToCalendarDto(this LeaveRequest leaveRequest)
        {
            CalendarDTO calendarDTO = new CalendarDTO();

            calendarDTO.EmployeeId = leaveRequest.EmployeeID;
            calendarDTO.LeaveRequestId = leaveRequest.ID;
            calendarDTO.EmployeeFirstName = leaveRequest.RequestedByEmployee.FirstName;
            calendarDTO.EmployeeLastName = leaveRequest.RequestedByEmployee.LastName;
            calendarDTO.LeaveStartDate = leaveRequest.LeaveStartDate;
            calendarDTO.LeaveEndDate = leaveRequest.LeaveEndDate;

            return calendarDTO;
        }
    }
}
