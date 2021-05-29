using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
    }
}
