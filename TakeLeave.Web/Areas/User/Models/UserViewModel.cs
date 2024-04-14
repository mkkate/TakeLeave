using System.ComponentModel;

namespace TakeLeave.Web.Areas.User.Models
{
    public class UserViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Start date")]
        public DateOnly EmploymentStartDate { get; set; }

        [DisplayName("End date")]
        public DateOnly? EmploymentEndDate { get; set; }


        public DaysOffViewModel DaysOff { get; set; } = new DaysOffViewModel();

        [DisplayName("Position")]
        public PositionViewModel Position { get; set; } = new PositionViewModel();
    }
}
