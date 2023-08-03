using AutoMapper;
using StokTakip.Products;
using static StokTakip.Web.Pages.Products.CreateModalModel;

namespace StokTakip.Web;

public class StokTakipWebAutoMapperProfile : Profile
{
    public StokTakipWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Create, CreateProduct>();
    }
}
