using System.ComponentModel.DataAnnotations;

namespace TakeLeave.Business.Models.LeaveRequests
{
    public enum LeaveRequestType
    {
        [Display(Name = "Vacation")]
        Vacation,
        [Display(Name = "Paid")]
        Paid,
        [Display(Name = "Unpaid")]
        Unpaid,
        [Display(Name = "Sick leave")]
        SickLeave
    }
}
