using Volo.Abp.Modularity;

namespace StokTakip;

[DependsOn(
    typeof(StokTakipApplicationModule),
    typeof(StokTakipDomainTestModule)
    )]
public class StokTakipApplicationTestModule : AbpModule
{

}
