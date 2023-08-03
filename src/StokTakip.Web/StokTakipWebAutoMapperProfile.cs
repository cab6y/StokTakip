using AutoMapper;
using StokTakip.Products;
using StokTakip.ProductSizes;
using StokTakip.Web.Pages.Products;
using static StokTakip.Web.Pages.Products.CreateModalModel;
using static StokTakip.Web.Pages.Products.EditModalModel;

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
    }
}
