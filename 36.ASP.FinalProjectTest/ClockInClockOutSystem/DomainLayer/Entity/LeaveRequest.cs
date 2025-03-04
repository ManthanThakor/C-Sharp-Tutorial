using System;
using System.ComponentModel.DataAnnotations;
using DomainLayer.common;
using DomainLayer.CustomValidation;
using DomainLayer.Enum;

namespace DomainLayer.Entity
{
    public class LeaveRequest : BaseEntity
    {
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DateGreaterThanOrEqual(nameof(StartDate), ErrorMessage = "End date must be the same or after the start date.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters.")]
        public string Reason { get; set; } = string.Empty;

        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        [Required(ErrorMessage = "Employee ID is required.")]
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
