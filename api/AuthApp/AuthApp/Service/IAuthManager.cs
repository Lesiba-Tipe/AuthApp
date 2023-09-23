using AuthApp.Dto;
using AuthApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IAuthManager
    {
        Task<bool> ValidateUserWithPassword(LogInDto user);
        Task<bool> ValidateUserWithEmail(string email);

        Task<string> GenerateJwtToken();
    }
}
