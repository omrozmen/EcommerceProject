using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Category1Id { get; set; }
        public int Category2Id { get; set; }
        public int Category3Id { get; set; }
        public string Category1Name { get; set; }
        public string Category2Name { get; set; }
        public string Category3Name { get; set; }
    }
}
