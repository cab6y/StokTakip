using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace StokTakip.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<bool> CreateAsync(CreateProduct input);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(ProductDto id);
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<PagedResultDto<ProductDto>> GetAllAsync(GetProductListDto input);
    }
}
