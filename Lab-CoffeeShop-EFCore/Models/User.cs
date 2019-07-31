using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_CoffeeShop_EFCore.Models
{
    public class User
    {
        public int UserId { get; set; }

        [RegularExpression("([a-zA-Z0-9 .&'-]+){4,20}", ErrorMessage = "User Name must be between 4 and 20 characters and cannot have special characters")]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("(?=.*[A-Z])(?=.*[@$!%*#?&]).{10,}", ErrorMessage = "Passwords must be at least 10 characters long, contain at least one upper case and one special character")]
        public string Password { get; set; }
    }
}
