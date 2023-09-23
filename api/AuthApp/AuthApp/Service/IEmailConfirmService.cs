using AuthApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public interface IEmailConfirmService
    {
        void GoogleSMTP( EmailDto  emailDto, int code);
    }
}
