using AuthApp.Dto;
using AuthApp.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> userManager;
        private User user;

        public AuthManager(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public string GenerateJwtToken(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fqhhLNdRJRKE4FbbiFMYHNybkI4qHZLb");

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[] 
                    { 
                        new Claim(ClaimTypes.Name, id), 
                        new Claim(ClaimTypes.Role, "User")
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "AuthApp",
                Audience = "https://localhost:44331/api/",
                
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return $"Bearer { tokenHandler.WriteToken(token)}";
        }

        public async Task<bool> ValidateUser(LogInDto _user)
        {
            //Find username
            user = await userManager.FindByEmailAsync(_user.Email);

            return (user != null && await userManager.CheckPasswordAsync(user, _user.Password));
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        
    }
}
