using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagmentDbContext _dbContext;
        public LeaveRequestRepository(LeaveManagmentDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(p => p.LeaveType).FirstOrDefaultAsync(p => p.Id == id);
            return leaveRequest;

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(p => p.LeaveType).ToListAsync();
            return leaveRequests;
        }
    }
}
