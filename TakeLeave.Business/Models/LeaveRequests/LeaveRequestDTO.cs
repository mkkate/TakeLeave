namespace TakeLeave.Business.Models.LeaveRequests
{
    public class LeaveRequestDTO
    {
        public int Id { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string? Comment { get; set; }

        public string Status { get; set; }
        public string LeaveType { get; set; }

        public int EmployeeID { get; set; }
        public string HrFirstName { get; set; }
        public string HrLastName { get; set; }
        public int? HandledByHrID { get; set; }

        public DaysOffDTO DaysOff { get; set; } = new();
    }
}
