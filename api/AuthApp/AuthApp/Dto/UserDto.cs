using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Dto
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDto
    {
        //public string Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
        
    }

    public class AccountDto : LogInDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
