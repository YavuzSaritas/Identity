using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "FirstName is REQUIRED!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is REQUIRED!")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is REQUIRED!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is REQUIRED!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
