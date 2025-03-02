using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.common;
using DomainLayer.Enum;

namespace DomainLayer.Entity
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

}
