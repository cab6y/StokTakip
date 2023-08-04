using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace StokTakip.Sales
{
    public class Sale : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public Guid? TenantId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerTelefon { get; set; }
    }
}
