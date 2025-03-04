using DomainLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOAttandaceAndService
{
    public class LeaveRequestDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class ApproveRejectLeaveDTO
    {
        public LeaveStatus Status { get; set; }
    }
}
