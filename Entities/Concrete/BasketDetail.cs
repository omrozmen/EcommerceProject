using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class BasketDetail: IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date_ { get; set; }

    }
}
