using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Input;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        //private readonly UserService userService;
        //private User user;
        private IConfigurationSection jwtOptions;

        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            //this.userService = userService;
            jwtOptions = configuration.GetSection("JwtOptions");
        }
 
        public async Task<string> GenerateJwtToken(User user)
        {
            //var jwtOptions = configuration.GetSection("JwtOptions");
            var key = Encoding.ASCII.GetBytes(jwtOptions.GetSection("Key").Value);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var results = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return results;
        }

        public async Task<bool> ValidateUserWithPassword(LoginInput loginInput)
        {
            //Find username
            var user = await userManager.FindByEmailAsync(loginInput.Email);

            return (user != null && await userManager.CheckPasswordAsync(user, loginInput.Password));
        }
       
        private async Task<List<Claim>> GetClaims(User user)
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
            var token = new JwtSecurityToken(
                issuer: jwtOptions.GetSection("Issuer").Value,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signingCredentials
                );

            return token;
        }

        public async Task<string> RequestPasswordToken(RequestPasswordInput requestPasswordDto)
        {
            var user = await userManager.FindByEmailAsync(requestPasswordDto.Email);

            var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);

            return passwordToken;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordInput resetPasswordDto)
        {
            var user = await userManager.FindByEmailAsync(resetPasswordDto.Email);

            var results = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);

            return results;
        }

        public async Task<string> RequestEmailToken(RequestEmailTokenInput requestEmailTokenInput)
        {
            var user = await userManager.FindByEmailAsync(requestEmailTokenInput.Email);

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            return token; 
        }

        public async Task<IdentityResult> ConfirmEmail(ConfirmEmailInput confrimEmailInput)
        {
            var user = await userManager.FindByEmailAsync(confrimEmailInput.Email);

            var results = await userManager.ConfirmEmailAsync(user, confrimEmailInput.Token);

            return results;
        }
    }
}
