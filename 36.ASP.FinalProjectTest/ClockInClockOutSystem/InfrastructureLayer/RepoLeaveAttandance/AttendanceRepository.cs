using DomainLayer.Entity;
using InfrastructureLayer.Data;
using InfrastructureLayer.InterRepoLeaveAttandance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.RepoLeaveAttandance
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.Include(a => a.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.Attendances.Where(a => a.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(Guid id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
        }

        public async Task DeleteAsync(Guid id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
