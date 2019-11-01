using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Searches
{
    public class ProductSearch
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string ProductName { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;

    }
}
