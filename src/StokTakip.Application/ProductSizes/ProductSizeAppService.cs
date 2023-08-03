using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace StokTakip.ProductSizes
{
    public class ProductSizeAppService :StokTakipAppService , IProductSizeAppService
    {
        private readonly IRepository<ProductSize,Guid> _productSizesRepository;
        public ProductSizeAppService(IRepository<ProductSize, Guid> productSizesRepository)
        {
            _productSizesRepository = productSizesRepository;
        }

        public async Task<bool> CreateAsync(CreateProductSize input)
        {
            try
            {
                var map = ObjectMapper.Map<CreateProductSize, ProductSize>(input);
                await _productSizesRepository.InsertAsync(map);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _productSizesRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedResultDto<ProductSizeDto>> GetAllAsync(GetProductSizeListDto filter)
        {
            try
            {
                List<ProductSizeDto> productsDto = new List<ProductSizeDto>();
                var totalCount = 0;
                var quarable = await _productSizesRepository.GetQueryableAsync();
                var query = from product in quarable
                           // where product.ProductId == ProductId
                            select new { product };

                query = query
                .Skip(filter.SkipCount)
                .Take(filter.MaxResultCount);
                var queryResult = await AsyncExecuter.ToListAsync(query);

                productsDto = queryResult.Select(x =>
                {
                    var productDto = ObjectMapper.Map<ProductSize, ProductSizeDto>(x.product);
                    return productDto;
                }).ToList();
                totalCount = filter.Filter == null
               ? await _productSizesRepository.CountAsync()
               : await _productSizesRepository.CountAsync();

                return new PagedResultDto<ProductSizeDto>(
                    totalCount,
                   productsDto
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductSizeDto> GetAsync(Guid id)
        {
            try
            {
                var get = await _productSizesRepository.GetAsync(id);
                return ObjectMapper.Map<ProductSize, ProductSizeDto>(get);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(ProductSizeDto input)
        {
            try
            {
                var get = await _productSizesRepository.GetAsync(input.Id);
                get.Size = input.Size;
                await _productSizesRepository.UpdateAsync(get);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
