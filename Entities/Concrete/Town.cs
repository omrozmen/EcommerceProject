using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Town: IEntity
    {
        public int Id { get; set; }
        public string TownName { get; set; }
    }
}
