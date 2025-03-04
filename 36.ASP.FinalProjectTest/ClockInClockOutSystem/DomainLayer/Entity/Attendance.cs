using System;
using System.ComponentModel.DataAnnotations;
using DomainLayer.common;

namespace DomainLayer.Entity
{
    public class Attendance : BaseEntity
    {
        [Required]
        public DateTime CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public TimeSpan? TotalWorkingHours { get; set; }
    }
}
