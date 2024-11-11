using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models.DTO
{
    public class RegisterDTO
    {
        // The username for the new user
        public string Username { get; set; }

        // The plain-text password (will be hashed during registration)
        public string Password { get; set; }

        // The role for the user (e.g., "Admin", "User")
        public string Role { get; set; }
    }
}
