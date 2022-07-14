using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Enums;

namespace ContactsControl.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter with user name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter with user login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter with user password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter with user e-mail")]
        [EmailAddress(ErrorMessage = "This e-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter with user profile")]
        public ProfileEnum? Profile { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool ValidPassword(string password)
        {
            return Password == password;
        }
    }
}
