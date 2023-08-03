using System;
using System.Collections.Generic;
using System.Text;

namespace StokTakip.ProductSizes
{
    public class CreateProductSize
    {
        public string Size { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
