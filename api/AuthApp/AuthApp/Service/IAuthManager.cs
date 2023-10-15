using AuthApp.Dto;
using AuthApp.Entity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IAuthManager
    {
        Task<bool> ValidateUserWithPassword(LogInDto user);
        //Task<bool> ValidateUserWithEmail(string email);
        Task<string> GenerateJwtToken(User user);

        Task<string> RequestPasswordToken(RequestPasswordDto requestPasswordDto);
        Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}
