using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using StokTakip.Permissions;
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
        [Authorize(StokTakipPermissions.Products.Create)]
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
        [Authorize(StokTakipPermissions.Products.Delete)]
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
        [Authorize(StokTakipPermissions.Products.Default)]
        public async  Task<PagedResultDto<ProductDto>> GetAllAsync(GetProductListDto input)
        {
            try
            {
                List<ProductDto> productsDto = new List<ProductDto>();
                var totalCount = 0;
                var quarable = await _productRepository.GetQueryableAsync();
                var query = from product in quarable
                            select new { product };

                var filter = new Filter();
                if (!input.Filter.IsNullOrWhiteSpace())
                {
                    List<FilterQuery> filterQuery = JsonConvert.DeserializeObject<List<FilterQuery>>(input.Filter);
                    foreach (FilterQuery item in filterQuery)
                    {
                        if (!string.IsNullOrEmpty(item.Value))
                        {

                            if (item.Path == "Name")
                            {
                                filter.Name = Convert.ToString(item.Value);
                            }
                            if (item.Path == "Gender")
                            {
                                filter.Gender = (GenderEnum)Convert.ToInt32(item.Value);
                            }

                        }
                    }
                    //throw new EntityNotFoundException(ex.Message.ToString());
                }
                if (filter.Name != null)
                {
                    //Paging
                    query = query.Where(x => x.product.Name.ToLower().Contains(filter.Name.ToLower()));

                }
                if (filter.Gender != GenderEnum.undifined)
                {
                    //Paging
                    query = query.Where(x => x.product.Gender == filter.Gender);

                }
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
        [Authorize(StokTakipPermissions.Products.Default)]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            try
            {
                var get = await _productRepository.GetAsync(id);
                return ObjectMapper.Map<Product, ProductDto>(get);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize(StokTakipPermissions.Products.Edit)]
        public async Task<bool> UpdateAsync(ProductDto input)
        {
            try
            {
                var get = await _productRepository.GetAsync(input.Id);
                get.Name = input.Name;
                get.image = input.image;
                get.Gender = input.Gender;
                get.Description = input.Description;
                await _productRepository.UpdateAsync(get);
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
            public string Name { get; set; }
            public GenderEnum Gender { get; set; } = GenderEnum.undifined;
        }
    }
}
