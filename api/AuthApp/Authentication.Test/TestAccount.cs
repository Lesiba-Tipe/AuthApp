using AuthApp.Entity;
using AuthApp.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Authentication.Test
{
    
   public class TestAccount
    {
        IAuthManager authManager;// = new AuthManager<User>();
        public TestAccount(IAuthManager _authManager)
        {
            authManager = _authManager;
        }

        //[Fact]
        public async Task ValidateLogin()
        {
            //Arrange
            User user = new User() { PasswordHash = "ofentse@gmail.com", UserName = "1234" };
            

            //Act
            var isValid = await authManager.validateUser(user);

            //Assert
            //Assert.False(isValid, $"The password {password} should not be valid!");
            Assert.True(isValid);
        }
    }
}
