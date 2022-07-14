using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsControl.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter with user login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter with user password")]
        public string Password { get; set; }
    }
}