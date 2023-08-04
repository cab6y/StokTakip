using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace StokTakip.Sales
{
    public class SaleAppService : StokTakipAppService , ISaleAppService
    {
        private readonly IRepository<Sale, Guid> _saleRepository;
        public SaleAppService(IRepository<Sale, Guid> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<bool> CreateAsync(CreateSale input)
        {
            try
            {
                var map = ObjectMapper.Map<CreateSale, Sale>(input);
                await _saleRepository.InsertAsync(map);
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
                await _saleRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SaleDto> GetAsync(Guid id)
        {
            try
            {
                var get = await _saleRepository.GetAsync(id);
                return ObjectMapper.Map<Sale,SaleDto>(get);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedResultDto<SaleDto>> GetListAsync(GetSaleListDto input)
        {
            try
            {
                List<SaleDto> productsDto = new List<SaleDto>();
                var totalCount = 0;
                var quarable = await _saleRepository.GetQueryableAsync();
                var query = from product in quarable
                            select new { product };

                query = query
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount);
                var queryResult = await AsyncExecuter.ToListAsync(query);

                productsDto = queryResult.Select(x =>
                {
                    var productDto = ObjectMapper.Map<Sale, SaleDto>(x.product);
                    return productDto;
                }).ToList();
                totalCount = input.Filter == null
               ? await _saleRepository.CountAsync()
               : await _saleRepository.CountAsync();

                return new PagedResultDto<SaleDto>(
                    totalCount,
                   productsDto
                );
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(SaleDto input)
        {
            try
            {
                var get = await _saleRepository.GetAsync(input.Id);
                get.Size = input.Size;
                get.CustomerEmail = input.CustomerEmail;
                get.Quantity = input.Quantity;
                get.CustomerName = input.CustomerName;
                get.CustomerSurName = input.CustomerSurName;
                get.CustomerEmail = input.CustomerEmail;
                get.CustomerTelefon = input.CustomerTelefon;
                await _saleRepository.UpdateAsync(get);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
