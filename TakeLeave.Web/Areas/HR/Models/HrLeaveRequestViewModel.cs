using System.ComponentModel;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class HrLeaveRequestViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName(DisplayNameConstants.LeaveStartDate)]
        public DateOnly LeaveStartDate { get; set; }

        [DisplayName(DisplayNameConstants.LeaveEndDate)]
        public DateOnly LeaveEndDate { get; set; }

        public string Status { get; set; }
        public string LeaveType { get; set; }

        public HashSet<string> LeaveTypes { get; set; }

        public int HandledByHrId { get; set; }

        public DaysOffViewModel DaysOff { get; set; } = new();
    }
}
