using StokTakip.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace StokTakip.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class StokTakipPageModel : AbpPageModel
{
    protected StokTakipPageModel()
    {
        LocalizationResourceType = typeof(StokTakipResource);
    }
}
