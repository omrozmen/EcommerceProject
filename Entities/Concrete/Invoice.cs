using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class Invoice: IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date_ { get; set; }
        public string CargoFicheNo { get; set; }
        public int Status_ { get; set; }

    }
}
