using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace StokTakip.Products
{
    public class ProductAppService : StokTakipAppService, IProductAppService
    {
        private readonly IRepository<Product,Guid> _productRepository;
        public ProductAppService(IRepository<Product, Guid> productRepository) {
            _productRepository = productRepository;
        }
        public async Task<bool> CreateAsync(CreateProduct input)
        {
            try
            {
                var map = ObjectMapper.Map<CreateProduct,Product>(input);
                await _productRepository.InsertAsync(map);
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
                await _productRepository.DeleteAsync(id);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async  Task<PagedResultDto<ProductDto>> GetAllAsync(GetProductListDto input)
        {
            try
            {
                List<ProductDto> productsDto = new List<ProductDto>();
                var totalCount = 0;
                var quarable = await _productRepository.GetQueryableAsync();
                var query = from product in quarable
                            select new { product };

                query = query
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount);
                var queryResult = await AsyncExecuter.ToListAsync(query);

                productsDto = queryResult.Select(x =>
                {
                    var productDto = ObjectMapper.Map<Product, ProductDto>(x.product);
                    return productDto;
                }).ToList();
                totalCount = input.Filter == null
               ? await _productRepository.CountAsync()
               : await _productRepository.CountAsync();

                return new PagedResultDto<ProductDto>(
                    totalCount,
                   productsDto
                );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(ProductDto input)
        {
            try
            {
                var get = await _productRepository.GetAsync(input.Id);
                get.Name = input.Name;
                get.image = input.image;
                get.Gender = input.Gender;
                await _productRepository.UpdateAsync(get);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
