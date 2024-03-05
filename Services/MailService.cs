using MyPersonalWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MyPersonalWebsite.Services
{
    public class MailService : IMailService
    {
        public readonly MailSettings _mailConfig;
        public MailService(MailSettings mailConfig)
        {
            _mailConfig=mailConfig;
        }

        public async Task SendMailAsync (string ForEmail, string Subject, string Body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailConfig.Username);
            message.To.Add(new MailAddress(_mailConfig.ToMail));
            message.Subject = ForEmail + " : " + Subject;
            message.Body = Body;
            smtp.Port = _mailConfig.Port;
            smtp.Host = _mailConfig.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailConfig.Username, _mailConfig.Password, _mailConfig.Host);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }

    }
}
