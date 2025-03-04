using ApplicationLayer.DTOAttandaceAndService;
using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InterServLeaveAttandace
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceDto>> GetAllAsync();
        Task<IEnumerable<AttendanceDto>> GetByEmployeeIdAsync(Guid employeeId);
        Task<AttendanceDto?> GetByIdAsync(Guid id);
        Task<bool> ClockInAsync(AttendanceCreateDto dto);
        Task<bool> ClockOutAsync(AttendanceUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
