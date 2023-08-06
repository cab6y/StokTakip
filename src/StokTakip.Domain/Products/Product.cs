using StokTakip.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace StokTakip.Products
{
    public class Product : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public GenderEnum Gender { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
        public Guid? TenantId { get; set; }
    }
}
