using AuthApp.Dto;
using AuthApp.Entity;
using AuthApp.Input;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IAuthManager
    {
        Task<bool> ValidateUserWithPassword(LoginInput user);
        //Task<bool> ValidateUserWithEmail(string email);
        Task<string> GenerateJwtToken(User user);
    }
}
