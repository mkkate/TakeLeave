using System.ComponentModel;
using TakeLeave.Business.Constants;

namespace TakeLeave.Web.Areas.User.Models
{
    public class DaysOffViewModel
    {
        public int? Vacation { get; set; }
        public int? Paid { get; set; }
        public int? Unpaid { get; set; }

        [DisplayName(DisplayNameConstants.SickLeave)]
        public int? SickLeave { get; set; }
    }
}
