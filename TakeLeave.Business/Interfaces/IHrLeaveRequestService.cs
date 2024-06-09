using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;

namespace TakeLeave.Business.Interfaces
{
    public interface IHrLeaveRequestService
    {
        List<HrLeaveRequestDTO> GetLeaveRequests();
        HrLeaveRequestDTO GetLeaveRequestById(int id);
        HashSet<string> GetLeaveTypes();
        void UpdateLeaveRequest(HrLeaveRequestDTO hrLeaveRequestDTO);
        void ApproveLeaveRequest(int id, int loggedHrId);
        void RejectLeaveRequest(int id, int loggedHrId);
        List<CalendarDTO> GetEmployeesOnLeave(DateTime date);
    }
}
