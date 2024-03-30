using System.ComponentModel.DataAnnotations.Schema;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Data.Database.LeaveRequests
{
    [Table("LeaveRequests")]
    public class LeaveRequest
    {
        public int ID { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string? Comment { get; set; }

        public LeaveRequestStatus Status { get; set; }
        public LeaveRequestType LeaveType { get; set; }


        public int EmployeeID { get; set; }
        public int? HandledByHrID { get; set; }


        public Employee RequestedByEmployee { get; set; }
        public Employee HandledByHr { get; set; }
    }
}
