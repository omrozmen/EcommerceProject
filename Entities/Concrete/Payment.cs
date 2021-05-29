using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Payment: IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentType { get; set; }
        public DateTime Date_ { get; set; }
        public int IsOk { get; set; }
        public string ApproveCode { get; set; }
        public string Error_ { get; set; }

    }
}
