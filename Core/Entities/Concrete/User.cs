using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrete
{
   public class User: IEntity
    {

        public int Id { get; set; }
        public string UserName_ { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public bool isAdmin { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public string Tel_Nr { get; set; }
        
    }
}
