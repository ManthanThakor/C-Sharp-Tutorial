using Domain.CommonEntity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNo { get; set; }
        public string UserPhoto { get; set; }

        public Guid UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }

        public virtual List<SupplierItem> SupplierItems { get; set; } = new List<SupplierItem>();
        public virtual List<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();
    }
}
