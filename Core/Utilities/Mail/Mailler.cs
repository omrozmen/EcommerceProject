using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;


namespace Core.Utilities.Mail
{
    public class Mailler : IMailler
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}

