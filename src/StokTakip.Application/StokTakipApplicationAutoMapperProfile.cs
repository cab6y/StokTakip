﻿using AutoMapper;
using StokTakip.Products;
using StokTakip.ProductSizes;
using StokTakip.Sales;
using Volo.Abp.Identity;

namespace StokTakip;

public class StokTakipApplicationAutoMapperProfile : Profile
{
    public StokTakipApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProduct, Product>();
        CreateMap<ProductSize, ProductSizeDto>();
        CreateMap<ProductSizeDto, ProductSize>();
        CreateMap<CreateProductSize, ProductSize>();
        CreateMap<Sale, SaleDto>();
        CreateMap<CreateSale, Sale>();
    }
}
