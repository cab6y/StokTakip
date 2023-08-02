using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace StokTakip.Web;

[Dependency(ReplaceServices = true)]
public class StokTakipBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StokTakip";
}
