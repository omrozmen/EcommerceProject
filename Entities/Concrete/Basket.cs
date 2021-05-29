using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class Basket: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int ProductCount { get; set; }
        public double TotalPrice { get; set; }
        public bool Status_ { get; set; }

    }
}
