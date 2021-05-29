using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Category1Id { get; set; }
        public int Category2Id { get; set; }
        public int Category3Id { get; set; }

    }
}
