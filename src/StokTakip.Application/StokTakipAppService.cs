using System;
using System.Collections.Generic;
using System.Text;
using StokTakip.Localization;
using Volo.Abp.Application.Services;

namespace StokTakip;

/* Inherit your application services from this class.
 */
public abstract class StokTakipAppService : ApplicationService
{
    protected StokTakipAppService()
    {
        LocalizationResource = typeof(StokTakipResource);
    }
}
