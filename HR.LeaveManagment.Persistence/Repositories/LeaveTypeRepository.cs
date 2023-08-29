using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagmentDbContext _dbcontext;
        public LeaveTypeRepository(LeaveManagmentDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }
    }
}
