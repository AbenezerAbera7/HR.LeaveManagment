using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Applicatiion.Contracts.Persistence
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
    {
    }
}
