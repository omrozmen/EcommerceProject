using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BasketId { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductCount { get; set; }
        public double TotalPrice { get; set; }
        public int Status_ { get; set; }

    }
}
