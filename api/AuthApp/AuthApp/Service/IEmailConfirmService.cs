using AuthApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IEmailConfirmService
    {
        void SendEmail(EmailDto emailDto, string userEmail);
        void GoogleSMTP( UserDto userDto, int code);
    }
}
