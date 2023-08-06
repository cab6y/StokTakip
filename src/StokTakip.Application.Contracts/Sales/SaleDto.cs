using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace StokTakip.Sales
{
    public class SaleDto : EntityDto<Guid>
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerTelefon { get; set; }
        public string? ProductName { get; set; }

    }
}
