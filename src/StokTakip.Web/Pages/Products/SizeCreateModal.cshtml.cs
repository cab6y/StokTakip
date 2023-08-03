using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StokTakip.ProductSizes;
using System;
using System.Threading.Tasks;

namespace StokTakip.Web.Pages.Products
{
    public class SizeCreateModalModel : StokTakipPageModel
    {
        private readonly IProductSizeAppService _productSizeAppService;
        [BindProperty]
        public CreateSize create { get; set; }
        public SizeCreateModalModel(IProductSizeAppService productSizeAppService)
        {
            _productSizeAppService = productSizeAppService;
        }
        public void OnGet(Guid id)
        {
            create = new CreateSize();
            create.ProductId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var map = ObjectMapper.Map<CreateSize, CreateProductSize>(create);
                await _productSizeAppService.CreateAsync(map);
                return NoContent();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class CreateSize
    {
        public string Size { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [HiddenInput]
        public Guid ProductId { get; set; }
    }
}
