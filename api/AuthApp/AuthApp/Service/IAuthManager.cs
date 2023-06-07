using AuthApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IAuthManager
    {
        Task<bool> validateUser(User user);
    }
}
