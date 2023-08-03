using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace StokTakip.Web.Pages.Products
{
    public class SizeListModalModel : StokTakipPageModel
    {
        public SizeListModalModel()
        {

        }
        [BindProperty]
        public size sizes { get; set; }
        public void OnGet(Guid id)
        {
            sizes = new size();
            sizes.ProductId = id;
        }
        public class size
        {
            [HiddenInput]
            public Guid ProductId { get; set; }
        }
    }
}
