using HR.LeaveManagment.Applicatiion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Applicatiion.Contracts.Infrstructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email); 
    }
}
