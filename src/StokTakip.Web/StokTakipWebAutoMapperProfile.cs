using AutoMapper;
using StokTakip.Products;
using StokTakip.ProductSizes;
using StokTakip.Sales;
using StokTakip.Web.Pages.Products;
using static StokTakip.Web.Pages.Products.CreateModalModel;
using static StokTakip.Web.Pages.Products.EditModalModel;
using static StokTakip.Web.Pages.Products.SaleModalModel;

namespace StokTakip.Web;

public class StokTakipWebAutoMapperProfile : Profile
{
    public StokTakipWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Create, CreateProduct>();
        CreateMap<ProductDto, Edit>();
        CreateMap<Edit, ProductDto>();
        CreateMap<CreateSize, CreateProductSize>();
        CreateMap<EditSize, ProductSizeDto>();
        CreateMap<CreateSalePage, CreateSale>();
    }
}
