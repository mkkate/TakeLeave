using System.ComponentModel;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.Models
{
    public class UserViewModel
    {
        [DisplayName(DisplayNameConstants.FirstName)]
        public string FirstName { get; set; }

        [DisplayName(DisplayNameConstants.LastName)]
        public string LastName { get; set; }

        [DisplayName(DisplayNameConstants.Address)]
        public string Address { get; set; }

        [DisplayName(DisplayNameConstants.StartDate)]
        public DateOnly EmploymentStartDate { get; set; }

        [DisplayName(DisplayNameConstants.EndDate)]
        public DateOnly? EmploymentEndDate { get; set; }


        public DaysOffViewModel DaysOff { get; set; } = new DaysOffViewModel();

        [DisplayName(DisplayNameConstants.Position)]
        public PositionViewModel Position { get; set; } = new PositionViewModel();
    }
}
