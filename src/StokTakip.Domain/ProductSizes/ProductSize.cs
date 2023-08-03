using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace StokTakip.ProductSizes
{
    public class ProductSize : AuditedAggregateRoot<Guid>
    {
        public string Size { get; set; }
        public string Description { get;set; }
        public Guid ProductId { get; set; }
    }
}
