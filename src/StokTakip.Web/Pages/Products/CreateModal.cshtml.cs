using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StokTakip.Products;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StokTakip.Web.Pages.Products
{
    public class CreateModalModel : StokTakipPageModel
    {
        private readonly IProductAppService _productAppService;

        [BindProperty]
        public Create? productInput { get; set; }
        [BindProperty]
        public UploadFileDto? UploadFileDtos { get; set; }
        public CreateModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var map = ObjectMapper.Map<Create,CreateProduct>(productInput);
                await _productAppService.CreateAsync(map);
                return NoContent();
            }
            catch(Exception ex)
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
        public class Create
        {
            public string? Name { get; set; }
            public GenderEnum? Gender { get; set; }
            [MaxLength(999999999)]
            public string? image { get; set; }
            [HiddenInput]
            public bool? IsActive { get; set; }
        }
    }
}
