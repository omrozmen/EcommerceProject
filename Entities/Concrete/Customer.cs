using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class Customer:IEntity
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string companyName { get; set; }
    }
}
