using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace StokTakip.ProductSizes
{
    public class ProductSize : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public string Size { get; set; }
        public string? Description { get;set; }
        public Guid ProductId { get; set; }
        public Guid? TenantId { get; set; }
        public int Quantity { get; set; }
    }
}
