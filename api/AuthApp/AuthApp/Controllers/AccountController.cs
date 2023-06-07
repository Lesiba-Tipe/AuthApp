using AuthApp.Entity;
using AuthApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;// = new UserManager<User>();

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task ValidateLogin()
        {
            //Arrange
            User user = new User() { PasswordHash = "ofentse@gmail.com", UserName = "1234" };

            //Find username
            var _user = await _userManager.FindByEmailAsync(user.UserName);

            if (_user != null)
            {
                //await _userManager.CheckPasswordAsync(user, user.PasswordHash);
                //return true;
            }

            


        }
    }
}
