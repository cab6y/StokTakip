using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace StokTakip.ProductSizes
{
    public class ProductSizeDto : EntityDto<Guid>
    {
        public string Size { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
