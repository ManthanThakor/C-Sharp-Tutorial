using Domain.CommonEntity;
using System;

namespace Domain.Models
{
    public class SupplierItem : BaseEntity
    {
        public Guid SupplierId { get; set; }
        public virtual User Supplier { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
