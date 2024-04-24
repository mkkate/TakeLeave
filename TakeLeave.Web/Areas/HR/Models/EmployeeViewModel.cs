using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TakeLeave.Business.Constants;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName(DisplayNameConstants.FirstName)]
        public string FirstName { get; set; }

        [DisplayName(DisplayNameConstants.LastName)]
        public string LastName { get; set; }

        [DisplayName(DisplayNameConstants.UserName)]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public string IDNumber { get; set; }

        [Required]
        [DisplayName(DisplayNameConstants.StartDate)]
        public DateTime EmploymentStartDate { get; set; }

        [Required]
        [DisplayName(DisplayNameConstants.EndDate)]
        public DateTime? EmploymentEndDate { get; set; }


        public DaysOffViewModel DaysOff { get; set; } = new DaysOffViewModel();


        [ValidateNever]
        public Tuple<HashSet<string>, List<string>> PositionTitlesAndSeniorityLevels { get; set; }
        public PositionViewModel Position { get; set; } = new PositionViewModel();
    }
}
