using AuthApp.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthApp.Service
{
    public class EmailConfirmService : IEmailConfirmService
    {
        private protected IConfiguration config;
        private IConfigurationSection googleSMTP;
        public EmailConfirmService(IConfiguration config)
        {
            this.config = config;

            googleSMTP = this.config.GetSection("GoogleSMTP");
        }
       
        
        public void GoogleSMTP(EmailDto emailDto, int code)
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
                    Subject = "AuthApp Confirmation",
                    Body = EmailBody(emailDto.Firstname, code),
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

        private string EmailBody(string firstname, int code)
        {
            return $"Hi {firstname}.\nPlease use this code {code} as your confirmtion.\n\nRegards \nAuth App Team";
        }
    }
}
