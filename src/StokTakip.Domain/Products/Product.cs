using StokTakip.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace StokTakip.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public GenderEnum Gender { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
    }
}
