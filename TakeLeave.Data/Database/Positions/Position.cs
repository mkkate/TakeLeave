using System.ComponentModel.DataAnnotations.Schema;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Data.Database.Positions
{
    [Table("Positions")]
    public class Position
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public int EmployeeRoleID { get; set; }
        public EmployeeRole EmployeeRole { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
