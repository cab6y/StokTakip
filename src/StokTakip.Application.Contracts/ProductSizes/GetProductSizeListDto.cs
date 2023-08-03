using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace StokTakip.ProductSizes
{
    public class GetProductSizeListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
