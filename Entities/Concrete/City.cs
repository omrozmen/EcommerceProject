﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
   public class City: IEntity
    {
        public int Id { get; set; }
        public string CityName { get; set; }

    }
}
