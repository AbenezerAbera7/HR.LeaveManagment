using AutoMapper;
using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveType;
using HR.LeaveManagment.Applicatiion.Exceptions;
using HR.LeaveManagment.Applicatiion.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagment.Applicatiion.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Applicatiion.Profiles;
using HR.LeaveManagment.Applicatiion.Responses;
using HR.LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagment.Application.UnitTests.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly CreateLeaveTypeDto _leaveTypeDto;
    private readonly CreateLeaveTypeCommandHandler _handler;
    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

        _leaveTypeDto = new CreateLeaveTypeDto()
        {
            
            DefaultDays = 4,
            Name = "Name Four",
        };
    }




    [Fact]
    public async Task Valid_LeaveType_Added()
    {
        var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

        var leaveTypes = await _mockRepo.Object.GetAll();

        result.ShouldBeOfType<BaseCommondResponse>();

        leaveTypes.Count.ShouldBe(3);
    }

    
}

