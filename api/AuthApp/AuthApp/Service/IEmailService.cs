using AuthApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IEmailService
    {
        Task GoogleSMTP( EmailDto  emailDto);
        string EmailBodyConfirm(string firstname, int code);
        string EmailBodySendPasswordToken(string firstname, string urlToken);
    }
}
