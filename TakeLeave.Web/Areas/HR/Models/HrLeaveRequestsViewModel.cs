namespace TakeLeave.Web.Areas.HR.Models
{
    public class HrLeaveRequestsViewModel
    {
        public List<HrLeaveRequestViewModel> HrLeaveRequests { get; set; } = new();
        public int LoggedInEmployeeId { get; set; }
    }
}
