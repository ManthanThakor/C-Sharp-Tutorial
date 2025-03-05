using ApplicationLayer.DTOAttandaceAndService;
using ApplicationLayer.InterServLeaveAttandace;
using DomainLayer.Entity;
using InfrastructureLayer.InterRepoLeaveAttandance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ServLeaveAttandace
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAllAsync()
        {
            var attendances = await _attendanceRepository.GetAllAsync();
            return attendances.Select(a => new AttendanceDto
            {
                Id = a.Id,
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime,
                TotalWorkingHours = a.TotalWorkingHours,
                EmployeeId = a.EmployeeId
            }).ToList();
        }

        public async Task<IEnumerable<AttendanceDto>> GetByEmployeeIdAsync(Guid employeeId)
        {
            var attendances = await _attendanceRepository.GetByEmployeeIdAsync(employeeId);
            return attendances.Select(a => new AttendanceDto
            {
                Id = a.Id,
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime,
                TotalWorkingHours = a.TotalWorkingHours,
                EmployeeId = a.EmployeeId
            }).ToList();
        }

        public async Task<AttendanceDto?> GetByIdAsync(Guid id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance == null) return null;

            return new AttendanceDto
            {
                Id = attendance.Id,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
                TotalWorkingHours = attendance.TotalWorkingHours,
                EmployeeId = attendance.EmployeeId
            };
        }

        public async Task<bool> ClockInAsync(AttendanceCreateDto dto)
        {
            var existingAttendance = (await _attendanceRepository.GetByEmployeeIdAsync(dto.EmployeeId))
                .FirstOrDefault(a => a.CheckOutTime == null);

            if (existingAttendance != null)
            {
                return false;
            }

            var attendance = new Attendance
            {
                Id = Guid.NewGuid(),
                CheckInTime = dto.CheckInTime,
                EmployeeId = dto.EmployeeId
            };

            await _attendanceRepository.AddAsync(attendance);
            await _attendanceRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClockOutAsync(AttendanceUpdateDto dto)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(dto.Id);
            if (attendance == null)
            {
                Console.WriteLine("Attendance record not found.");
                return false;
            }

            if (attendance.CheckOutTime != null)
            {
                Console.WriteLine("User already clocked out.");
                return false;
            }

            attendance.CheckOutTime = dto.CheckOutTime ?? DateTime.UtcNow;
            attendance.TotalWorkingHours = attendance.CheckOutTime.Value - attendance.CheckInTime;

            await _attendanceRepository.UpdateAsync(attendance);
            await _attendanceRepository.SaveChangesAsync();

            Console.WriteLine("Clock-Out successful.");
            return true;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            await _attendanceRepository.DeleteAsync(id);
            await _attendanceRepository.SaveChangesAsync();
            return true;
        }
    }
}
