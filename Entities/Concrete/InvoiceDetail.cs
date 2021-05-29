using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class InvoiceDetail: IEntity
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

    }
}
