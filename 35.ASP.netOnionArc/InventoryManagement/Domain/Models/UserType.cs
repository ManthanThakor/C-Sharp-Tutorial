using Domain.CommonEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class UserType : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
