using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TakeLeave.Business.Constants;

namespace TakeLeave.Web.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel()
        {
            [Required]
            [DisplayName(DisplayNameConstants.UserName)]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
