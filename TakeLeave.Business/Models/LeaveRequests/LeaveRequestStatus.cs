using System.ComponentModel.DataAnnotations;

namespace TakeLeave.Business.Models.LeaveRequests
{
    public enum LeaveRequestStatus
    {
        [Display(Name = "On wait")]
        OnWait,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Rejected")]
        Rejected
    }
}
