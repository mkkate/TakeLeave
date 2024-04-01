using System.ComponentModel.DataAnnotations.Schema;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Data.Database.DaysOffs
{
    [Table("DaysOffs")]
    public class DaysOff
    {
        public int ID { get; set; }
        public int? Vacation { get; set; }
        public int? Paid { get; set; }
        public int? Unpaid { get; set; }
        public int? SickLeave { get; set; }

        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }
    }
}
