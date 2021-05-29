using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class SmtpSettings:IEntity
    {
        public int Id { get; set; }
        public int Port { get; set; }
        public string Server{ get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
