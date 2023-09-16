using AuthApp.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;

namespace AuthApp.Service
{
    public class EmailConfirmService : IEmailConfirmService
    {
        
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
    }
}
