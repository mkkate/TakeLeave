using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TakeLeave.Data.Database.ChatMessages;
using TakeLeave.Data.Database.DaysOffs;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Database.Positions;

namespace TakeLeave.Data.Database.Employees
{
    public class Employee : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string IDNumber { get; set; }

        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsAdmin { get; set; }


        public int DaysOffID { get; set; }
        public int PositionID { get; set; }


        public DaysOff DaysOff { get; set; }
        public Position Position { get; set; }
        public ICollection<LeaveRequest> EmployeeLeaveRequests { get; } = new List<LeaveRequest>();
        public ICollection<LeaveRequest>? HandledLeaveRequests { get; } = new List<LeaveRequest>();

        public ICollection<ChatMessage> SentMessages { get; } = new List<ChatMessage>();
        public ICollection<ChatMessage> ReceivedMessages { get; } = new List<ChatMessage>();
    }
}
