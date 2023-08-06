using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using StokTakip.Products;

namespace StokTakip.Web.Pages.Products
{
    public class EditModalModel : StokTakipPageModel
    {
        private readonly IProductAppService _productAppService;

        [BindProperty]
        public Edit? productInput { get; set; }
        [BindProperty]
        public UploadFileDto? UploadFileDtos { get; set; }
        public EditModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                var get = await _productAppService.GetByIdAsync(id);
                productInput = ObjectMapper.Map<ProductDto, Edit>(get);
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
                var map = ObjectMapper.Map<Edit, ProductDto>(productInput);
                await _productAppService.UpdateAsync(map);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public class UploadFileDto
        {
            [Display(Name = "Resim")]
            public IFormFile? File { get; set; }

            [HiddenInput]
            public string? Name { get; set; }
        }
        public class Edit
        {
            [HiddenInput]
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public GenderEnum? Gender { get; set; }
            [MaxLength(999999999)]
            [HiddenInput]
            public string? image { get; set; }
            [HiddenInput]
            public bool? IsActive { get; set; }
        }
    }
}
