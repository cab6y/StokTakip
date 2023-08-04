using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StokTakip.Permissions;

namespace StokTakip.Web.Pages.Products
{
    [Authorize(StokTakipPermissions.Products.Default)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
