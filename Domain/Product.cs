﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
