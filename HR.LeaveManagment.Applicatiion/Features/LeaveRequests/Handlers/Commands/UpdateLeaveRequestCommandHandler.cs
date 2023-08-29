using AutoMapper;
using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveRequest.Validators;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveType.Validators;
using HR.LeaveManagment.Applicatiion.Exceptions;
using HR.LeaveManagment.Applicatiion.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Applicatiion.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository ,IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var leaveRequest = await _leaveRequestRepository.Get(request.LeaveRequestDto.Id);

            if (request.LeaveRequestDto != null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
