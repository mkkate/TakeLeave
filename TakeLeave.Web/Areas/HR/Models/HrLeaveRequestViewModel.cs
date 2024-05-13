﻿using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class HrLeaveRequestViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string? Comment { get; set; }

        public string Status { get; set; }
        public string LeaveType { get; set; }

        public int HandledByHrId { get; set; }

        public DaysOffViewModel DaysOff { get; set; } = new();
    }
}
