using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.BaseEntity
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
