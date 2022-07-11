using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsControl.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter with contact name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter with contact e-mail")]
        [EmailAddress(ErrorMessage = "This e-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter with contact phone")]
        [Phone(ErrorMessage = "This phone is not valid")]
        public string Phone { get; set; }
    }
}
