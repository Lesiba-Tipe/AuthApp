using AuthApp.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

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

        public void SendEmail(EmailDto emailDto, string userEmail)
        {
            var email = "lesibamoshweu@gmail.com";
            var password = "mvlpuoefuoklondo";

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(email);
                message.To.Add(new MailAddress(userEmail));
                message.Subject = emailDto.Subject;
                message.IsBodyHtml = false; //to make message body as html
                message.Priority = MailPriority.Normal;
                message.Body = emailDto.Body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) 
            {
                //logger.LogDebug(ex.Message);
                var msg = ex.Message;
            }
        }
        
        public void GoogleSMTP(UserDto userDto, int code)
        {
            try
            {
                var c = googleSMTP.GetSection("Client").Value;
                var p = googleSMTP.GetSection("Port").Value;
                var e = googleSMTP.GetSection("Email").Value;
                var pa = googleSMTP.GetSection("Password").Value;

                var test = config["GoogleSMTP:Client"];

                var smtpClient = new SmtpClient(googleSMTP.GetSection("Client").Value)
                {
                    Port = Convert.ToInt32(googleSMTP.GetSection("Port").Value),
                    Credentials = new NetworkCredential(googleSMTP.GetSection("Email").Value, googleSMTP.GetSection("Password").Value),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(userDto.Email),
                    Subject = "AuthApp Confirmation",
                    Body = EmailBody(userDto.Firstname, code),
                    IsBodyHtml = false,
                    To = { userDto.Email }
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
            return $"Hi {firstname}.\nPlease use this code {code} as your confirmtion.\n\nRegards \nAuth App Team (EmailBody)";
        }
    }
}
