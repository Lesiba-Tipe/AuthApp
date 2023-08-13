using Microsoft.AspNetCore.Identity;
using System;

namespace AuthApp.Entity
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; } 
        public string Lastname { get; set; }
        
    }
}
