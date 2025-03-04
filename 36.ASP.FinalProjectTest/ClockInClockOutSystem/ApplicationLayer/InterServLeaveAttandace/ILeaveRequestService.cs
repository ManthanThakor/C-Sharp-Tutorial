using ApplicationLayer.DTOAttandaceAndService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InterServLeaveAttandace
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequestDTO>> GetAllLeaveRequests();
        Task<IEnumerable<LeaveRequestDTO>> GetEmployeeLeaveRequests(Guid employeeId);
        Task AddLeaveRequest(LeaveRequestDTO leaveRequest);
        Task ApproveOrRejectLeave(Guid id, ApproveRejectLeaveDTO leave);
    }
}
