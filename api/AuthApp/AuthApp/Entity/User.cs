using Microsoft.AspNetCore.Identity;

namespace AuthApp.Entity
{
    public class User //: IdentityUser
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public User()
        {
            UserName = "ofentse@gmail.com";
            PasswordHash = "1234";
        }


    }
}
