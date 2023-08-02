using StokTakip.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace StokTakip.Products
{
    public class EfCoreProductRepository : EfCoreRepository<StokTakipDbContext, Product , Guid>, IRepository<Product , Guid>
    {
        public EfCoreProductRepository(
        IDbContextProvider<StokTakipDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

    }
}
