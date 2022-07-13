using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Enums;

namespace ContactsControl.Models
{
    public class UserWithoutPasswordModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter with user name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter with user login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter with user password")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter with user profile")]
        public ProfileEnum? Profile { get; set; }
    }
}
