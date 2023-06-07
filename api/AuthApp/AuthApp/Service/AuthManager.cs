using AuthApp.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;// = new UserManager<User>();
        private User _user;

        public AuthManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> validateUser(User user)
        {
            //Find username
            _user = await _userManager.FindByEmailAsync(user.UserName);

            if (_user != null)
            {
                await _userManager.CheckPasswordAsync(user, user.PasswordHash);
                return true;
            }

            return false;
        }
    }
}
