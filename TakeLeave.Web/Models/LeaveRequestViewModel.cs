namespace TakeLeave.Web.Models
{
    public class LeaveRequestViewModel
    {
        public int Id { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string? Comment { get; set; }

        public string Status { get; set; }
        public string LeaveType { get; set; }

        public int HandledByHrId { get; set; }

        public DaysOffViewModel DaysOff { get; set; } = new();
    }
}
