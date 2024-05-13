using TakeLeave.Business.Models.LeaveRequests;

namespace TakeLeave.Business.Interfaces
{
    public interface IHrLeaveRequestService
    {
        List<HrLeaveRequestDTO> GetLeaveRequests();
    }
}
