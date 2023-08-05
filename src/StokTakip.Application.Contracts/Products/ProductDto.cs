using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace StokTakip.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public GenderEnum Gender { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
        public string? sizeDescription { get; set; }
    }
}
