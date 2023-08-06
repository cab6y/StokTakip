using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakip.ProductSizes;
using StokTakip.Sales;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
namespace StokTakip.Web.Pages.Products
{
    public class SaleModalModel : StokTakipPageModel
    {
        private readonly ISaleAppService _saleAppService;
        private readonly IProductSizeAppService _sizeAppService;
        public SaleModalModel(ISaleAppService saleAppService, IProductSizeAppService sizeAppService)
        {
            _saleAppService = saleAppService;
            _sizeAppService = sizeAppService;
        }
        public List<SelectListItem>? _sizes { get; set; }
        [BindProperty]
        public CreateSalePage sale { get; set; } = new CreateSalePage();
        public async Task<IActionResult> OnGetAsync(Guid productId)
        {
            try
            {
                sale.ProductId = productId;
                var sizes = await _sizeAppService.GetSizeList(productId);
                _sizes = sizes.Items.Select(x => new SelectListItem(x.Size , x.Id.ToString())).ToList();
                return Page();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var size = await _sizeAppService.GetAsync(sale.SizeId);
                size.Quantity = size.Quantity - sale.Quantity;
                sale.Size = size.Size;
                if (size.Quantity > 0)
                {
                    await _sizeAppService.UpdateAsync(size);
                    await _saleAppService.CreateAsync(ObjectMapper.Map<CreateSalePage, CreateSale>(sale));
                }
                if (size.Quantity == 0)
                {
                    await _sizeAppService.DeleteAsync(size.Id);
                    await _saleAppService.CreateAsync(ObjectMapper.Map<CreateSalePage,CreateSale>(sale));
                }
                if (size.Quantity < 0)
                {
                    throw new Exception("Bu bedenden girilen adet kadar stok bulunmamakta");
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        public class CreateSalePage
        {
            [HiddenInput]
            public Guid ProductId { get; set; }
            [SelectItems(nameof(_sizes))]
            public Guid SizeId { get; set; }
            [HiddenInput]
            public string? Size { get; set; }
            public int Quantity { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerSurName { get; set; }
            public string? CustomerEmail { get; set; }
            public string? CustomerTelefon { get; set; }

        }
    }
}
