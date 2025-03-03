using Domain.CommonEntity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class UserType : BaseEntity
    {
        public string TypeName { get; set; }

        [JsonIgnore]
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
