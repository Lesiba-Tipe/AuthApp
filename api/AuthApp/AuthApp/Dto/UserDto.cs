using System.Collections.Generic;

namespace AuthApp.Dto
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDto : LogInDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }

    }

}
