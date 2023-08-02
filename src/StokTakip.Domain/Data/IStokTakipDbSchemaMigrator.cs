using System.Threading.Tasks;

namespace StokTakip.Data;

public interface IStokTakipDbSchemaMigrator
{
    Task MigrateAsync();
}
