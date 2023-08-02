using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace StokTakip.Data;

/* This is used if database provider does't define
 * IStokTakipDbSchemaMigrator implementation.
 */
public class NullStokTakipDbSchemaMigrator : IStokTakipDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
