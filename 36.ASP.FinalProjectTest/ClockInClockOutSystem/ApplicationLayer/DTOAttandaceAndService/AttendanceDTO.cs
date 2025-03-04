using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOAttandaceAndService
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public TimeSpan? TotalWorkingHours { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class AttendanceCreateDto
    {
        public DateTime CheckInTime { get; set; }
        public Guid EmployeeId { get; set; }
    }

    public class AttendanceUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}
