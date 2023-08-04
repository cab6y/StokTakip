using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace StokTakip.Sales
{
    public interface ISaleAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateSale input);
        Task<bool> UpdateAsync(SaleDto input);
        Task<PagedResultDto<SaleDto>> GetListAsync(GetSaleListDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<SaleDto> GetAsync(Guid id);
    }
}
