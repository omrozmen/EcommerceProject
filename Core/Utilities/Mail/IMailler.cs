using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
    public interface IMailler
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
