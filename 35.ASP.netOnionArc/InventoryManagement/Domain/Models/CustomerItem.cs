using Domain.CommonEntity;
using System;

namespace Domain.Models
{
    public class CustomerItem : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
