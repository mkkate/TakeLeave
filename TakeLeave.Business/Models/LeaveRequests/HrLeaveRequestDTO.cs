namespace TakeLeave.Business.Models.LeaveRequests
{
    public class HrLeaveRequestDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string Status { get; set; }
        public string LeaveType { get; set; }
        public int? HandledByHrID { get; set; }
        public int RequestedByEmployeeID { get; set; }

        public DaysOffDTO DaysOff { get; set; } = new();
    }
}
