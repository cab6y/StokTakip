using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StokTakip.ProductSizes;
using System;
using System.Threading.Tasks;
using static StokTakip.Web.Pages.Products.EditModalModel;


namespace StokTakip.Web.Pages.Products
{
    public class SizeEditModalModel : StokTakipPageModel
    {
        private readonly IProductSizeAppService _productSizeAppService;
        [BindProperty]
        public EditSize edit { get; set; }
        public SizeEditModalModel(IProductSizeAppService productSizeAppService)
        {
            _productSizeAppService = productSizeAppService;
        }
        public async void OnGet(Guid id)
        {
            try
            {
                edit = new EditSize();
                edit.Id = id;
                var get = await _productSizeAppService.GetAsync(id);
                edit.Description = get.Description;
                edit.Size = get.Size;
                edit.ProductId = get.ProductId;
                edit.Quantity = get.Quantity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var map = ObjectMapper.Map<EditSize, ProductSizeDto>(edit);
                await _productSizeAppService.UpdateAsync(map);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class EditSize
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        [HiddenInput]
        public Guid ProductId { get; set; }
    }
}

