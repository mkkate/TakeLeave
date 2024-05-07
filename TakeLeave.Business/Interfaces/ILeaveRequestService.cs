using TakeLeave.Business.Models.LeaveRequests;

namespace TakeLeave.Business.Interfaces
{
    public interface ILeaveRequestService
    {
        void CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO);
    }
}
