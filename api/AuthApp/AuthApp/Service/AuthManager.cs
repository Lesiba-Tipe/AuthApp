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

        public async Task<string> GenerateJwtToken()
        {
            var key = Encoding.ASCII.GetBytes("fqhhLNdRJRKE4FbbiFMYHNybkI4qHZLb");

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var results = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return results;
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

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            //var jwtSettings = _config.GetSection("JwtOptions");

            //var expiration = DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings.GetSection("LifeTime").Value));

            var token = new JwtSecurityToken(
                issuer: "AuthApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
                );

            return token;
        }


    }
}
