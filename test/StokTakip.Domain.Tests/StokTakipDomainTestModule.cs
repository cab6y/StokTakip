using StokTakip.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace StokTakip;

[DependsOn(
    typeof(StokTakipEntityFrameworkCoreTestModule)
    )]
public class StokTakipDomainTestModule : AbpModule
{

}
