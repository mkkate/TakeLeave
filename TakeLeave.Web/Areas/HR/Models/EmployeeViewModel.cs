using TakeLeave.Web.Areas.User.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DaysOffViewModel DaysOff { get; set; } = new DaysOffViewModel();
        public PositionViewModel Position { get; set; } = new PositionViewModel();
    }
}
