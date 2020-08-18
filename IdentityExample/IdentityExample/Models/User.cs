using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Models
{
    public class User : IdentityUser
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
    }
}
