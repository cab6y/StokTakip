﻿using AutoMapper;
using StokTakip.Products;
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
    }
}
