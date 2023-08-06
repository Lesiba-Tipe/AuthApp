using Microsoft.AspNetCore.Identity;


namespace AuthApp.Entity
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
