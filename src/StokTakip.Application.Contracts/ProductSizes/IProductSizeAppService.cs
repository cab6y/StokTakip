using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace StokTakip.ProductSizes
{
    public interface IProductSizeAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateProductSize input);
        Task<bool> UpdateAsync(ProductSizeDto input);
        Task<ProductSizeDto> GetAsync(Guid id);
        Task<PagedResultDto<ProductSizeDto>> GetAllAsync(GetProductSizeListDto filter);
        Task<bool> DeleteAsync(Guid id);
    }
}
