using System;
using System.Collections.Generic;
using System.Text;

namespace StokTakip.Sales
{
    public class CreateSale
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerTelefon { get; set; }
    }
}
