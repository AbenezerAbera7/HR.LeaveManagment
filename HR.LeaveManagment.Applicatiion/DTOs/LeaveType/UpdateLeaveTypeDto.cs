using FluentValidation;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveType.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Applicatiion.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDto()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} Must be present.");
        }
    }
}
