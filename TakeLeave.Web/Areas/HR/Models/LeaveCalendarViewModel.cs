using TakeLeave.Business.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class LeaveCalendarViewModel
    {
        public DateTime Date { get; set; }
        public List<CalendarDTO> EmployeesOnLeave { get; set; }
    }
}
