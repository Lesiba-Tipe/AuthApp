using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Input
{
    public class Register
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class GoogleRegisterInput : Register
    {

    }

    public class RegisterInput : Register
    {
        public string Password { get; set; }
    }

}
