using System;
using System.Collections.Generic;
using System.Text;

namespace StokTakip.Products
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string? Description { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
    }
}
