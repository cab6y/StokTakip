using StokTakip.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace StokTakip.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StokTakipController : AbpControllerBase
{
    protected StokTakipController()
    {
        LocalizationResource = typeof(StokTakipResource);
    }
}
