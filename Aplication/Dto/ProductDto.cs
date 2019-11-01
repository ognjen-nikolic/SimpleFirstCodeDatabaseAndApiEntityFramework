using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
    }
}
