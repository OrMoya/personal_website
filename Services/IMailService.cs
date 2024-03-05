using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalWebsite.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string FromEmail, string Subject, string Body);
    }
}
