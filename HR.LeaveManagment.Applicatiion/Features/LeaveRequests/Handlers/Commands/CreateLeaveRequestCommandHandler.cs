using AutoMapper;
using FluentValidation;
using FluentValidation.Internal;
using HR.LeaveManagment.Applicatiion.Contracts.Infrstructure;
using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveRequest.Validators;
using HR.LeaveManagment.Applicatiion.Exceptions;
using HR.LeaveManagment.Applicatiion.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagment.Applicatiion.Models;
using HR.LeaveManagment.Applicatiion.Responses;
using HR.LeaveManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = HR.LeaveManagment.Applicatiion.Exceptions.ValidationException;

namespace HR.LeaveManagment.Applicatiion.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommondResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;  
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository,IEmailSender emailSender ,IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;   
            
        }
        public async Task<BaseCommondResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommondResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(p => p.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} has been submitted successfully",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {

            }


            return response;
        }
    }
}
