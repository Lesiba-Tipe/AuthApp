using AuthApp.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public class EmailService : IEmailService
    {
        //private protected IConfiguration config;
        private IConfigurationSection googleSMTP, angularClient;
        public EmailService(IConfiguration config)
        {
            googleSMTP = config.GetSection("GoogleSMTP");
            angularClient = config.GetSection("AngularClient");
        }
       
        public async Task GoogleSMTP(EmailDto emailDto)
        {
            try
            {

                var smtpClient = new SmtpClient(googleSMTP.GetSection("Client").Value)
                {
                    Port = Convert.ToInt32(googleSMTP.GetSection("Port").Value),
                    Credentials = new NetworkCredential(googleSMTP.GetSection("Email").Value, googleSMTP.GetSection("Password").Value),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailDto.Email),
                    Subject = emailDto.Subject,
                    Body = emailDto.Body,
                    IsBodyHtml = false,
                    Priority = MailPriority.Normal,
                    To = { emailDto.Email }
                };

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw new Exception(msg);
            }
        }

        public string EmailBodyConfirm(string firstname, int code)
        {
            return $"Hi {firstname}.\nPlease use this code {code} as your confirmtion.\n\nRegards \nAero Space Team";
        }

        public string EmailBodySendPasswordToken(string firstname, string urlToken)
        {
            return $"Hi {firstname}.\nPlease use this link { urlToken } to reset your password." +
                $"\nThis link is valid for 2 hours.\n\nRegards \nAero Space Team";
        }

    }
}
