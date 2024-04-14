using System.ComponentModel;

namespace TakeLeave.Web.Areas.User.Models
{
    public class DaysOffViewModel
    {
        public int? Vacation { get; set; }
        public int? Paid { get; set; }
        public int? Unpaid { get; set; }
        [DisplayName("Sick leave")]
        public int? SickLeave { get; set; }
    }
}
