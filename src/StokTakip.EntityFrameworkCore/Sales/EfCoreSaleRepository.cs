using StokTakip.EntityFrameworkCore;
using StokTakip.ProductSizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace StokTakip.Sales
{
    public class EfCoreSaleRepository : EfCoreRepository<StokTakipDbContext, Sale, Guid>, IRepository<Sale, Guid>
    {
        public EfCoreSaleRepository(
       IDbContextProvider<StokTakipDbContext> dbContextProvider)
       : base(dbContextProvider)
        {
        }
    }
}
