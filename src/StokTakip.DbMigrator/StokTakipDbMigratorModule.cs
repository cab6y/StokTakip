using StokTakip.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace StokTakip.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StokTakipEntityFrameworkCoreModule),
    typeof(StokTakipApplicationContractsModule)
    )]
public class StokTakipDbMigratorModule : AbpModule
{
}
