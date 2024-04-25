using System.ComponentModel;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class EmployeeInfoViewModel
    {
        public int Id { get; set; }

        [DisplayName(DisplayNameConstants.FirstName)]
        public string FirstName { get; set; }

        [DisplayName(DisplayNameConstants.LastName)]
        public string LastName { get; set; }

        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DaysOffViewModel DaysOff { get; set; } = new DaysOffViewModel();

        [DisplayName(DisplayNameConstants.Position)]
        public PositionViewModel Position { get; set; } = new PositionViewModel();
    }
}
