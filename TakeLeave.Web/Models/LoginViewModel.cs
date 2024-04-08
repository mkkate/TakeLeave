using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
