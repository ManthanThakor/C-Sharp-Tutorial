using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.common;

namespace DomainLayer.Entity
{
    public class Attendance : BaseEntity
    {
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }

}
