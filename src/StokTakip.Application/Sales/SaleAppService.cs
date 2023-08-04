﻿using Microsoft.AspNetCore.Authorization;
using StokTakip.Permissions;
using StokTakip.Products;
using StokTakip.ProductSizes;
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
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<ProductSize, Guid> _productSizeRepository;
        public SaleAppService(IRepository<Sale, Guid> saleRepository,
            IRepository<Product, Guid> productRepository,
            IRepository<ProductSize, Guid> productSizeRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _productSizeRepository = productSizeRepository;
        }
        [Authorize(StokTakipPermissions.Sales.Create)]

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
        [Authorize(StokTakipPermissions.Sales.Delete)]
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var quarable2 = await _saleRepository.GetQueryableAsync();
                var quarable3 = await _productSizeRepository.GetQueryableAsync();
                var get = quarable2.Where(x => x.Id == id).FirstOrDefault();
                var getSize = quarable3.Where(x => x.ProductId == get.ProductId).FirstOrDefault();
                getSize.Quantity = getSize.Quantity + get.Quantity;
                await _productSizeRepository.UpdateAsync(getSize);
                await _saleRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Authorize(StokTakipPermissions.Sales.Default)]
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
        [Authorize(StokTakipPermissions.Sales.Default)]
        public async Task<PagedResultDto<SaleDto>> GetListAsync(GetSaleListDto input)
        {
            try
            {
                List<SaleDto> productsDto = new List<SaleDto>();
                var totalCount = 0;
                var quarable = await _saleRepository.GetQueryableAsync();
                var quarable2 = await _productSizeRepository.GetQueryableAsync();
                var quarable3 = await _productRepository.GetQueryableAsync();
                var query = from sale in quarable
                            join size in quarable2 on sale.ProductId equals size.ProductId
                            join product in quarable3 on sale.ProductId equals product.Id
                            select new { sale , size , product};

                query = query
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount);
                var queryResult = await AsyncExecuter.ToListAsync(query);

                productsDto = queryResult.Select(x =>
                {
                    var productDto = ObjectMapper.Map<Sale, SaleDto>(x.sale);
                    productDto.ProductName = x.product.Name;
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
        [Authorize(StokTakipPermissions.Sales.Edit)]
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
