namespace TakeLeave.Business.Models
{
    public class CalendarDTO
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public string LeaveType { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveRequestId { get; set; }
    }
}
