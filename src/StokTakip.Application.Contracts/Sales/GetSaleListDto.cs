using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace StokTakip.Sales
{
    public class GetSaleListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
