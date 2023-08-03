using StokTakip.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace StokTakip.ProductSizes
{
    public class EfCoreProductSizeRepository : EfCoreRepository<StokTakipDbContext, ProductSize, Guid>, IRepository<ProductSize, Guid>
    {
        public EfCoreProductSizeRepository(
       IDbContextProvider<StokTakipDbContext> dbContextProvider)
       : base(dbContextProvider)
        {
        }
    }
}
