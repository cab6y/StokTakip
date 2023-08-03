using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using static StokTakip.ProductSizes.ProductSizeAppService;

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

        public async Task<PagedResultDto<ProductSizeDto>> GetAllAsync(GetProductSizeListDto input)
        {
            try
            {
                List<ProductSizeDto> productsDto = new List<ProductSizeDto>();
                var totalCount = 0;
                var quarable = await _productSizesRepository.GetQueryableAsync();
                
                var query = from product in quarable
                           // where product.ProductId == ProductId
                            select new { product };
                var filter = new Filter();
                if (!input.Filter.IsNullOrWhiteSpace())
                {
                    List<FilterQuery> filterQuery = JsonConvert.DeserializeObject<List<FilterQuery>>(input.Filter);
                    foreach (FilterQuery item in filterQuery)
                    {
                        if (!string.IsNullOrEmpty(item.Value))
                        {

                            if (item.Path == "Size")
                            {
                                filter.ProductId = Guid.Parse(item.Value);
                            }
                            
                        }
                    }
                    //throw new EntityNotFoundException(ex.Message.ToString());
                }
                if (!filter.ProductId.ToString().IsNullOrWhiteSpace())
                {
                    //Paging
                    query = query.Where(x => x.product.ProductId == filter.ProductId);

                }
                query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
                var queryResult = await AsyncExecuter.ToListAsync(query);

                productsDto = queryResult.Select(x =>
                {
                    var productDto = ObjectMapper.Map<ProductSize, ProductSizeDto>(x.product);
                    return productDto;
                }).ToList();
                totalCount = input.Filter == null
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
                get.Description = input.Description;
                get.Quantity = input.Quantity;
                await _productSizesRepository.UpdateAsync(get);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class FilterQuery
        {
            public string Value { get; set; }
            public string Condition { get; set; }
            public string Path { get; set; }
        }
        public class Filter
        {
            public Guid ProductId { get; set; }
        }
    }
}
