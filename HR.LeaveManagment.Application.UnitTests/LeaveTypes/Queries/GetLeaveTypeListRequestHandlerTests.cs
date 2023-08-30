using AutoMapper;
using HR.LeaveManagment.Applicatiion.Contracts.Persistence;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveType;
using HR.LeaveManagment.Applicatiion.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagment.Applicatiion.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagment.Applicatiion.Profiles;
using HR.LeaveManagment.Application.UnitTests.Mocks;
using HR.LeaveManagment.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagment.Application.UnitTests.LeaveTypes.Queries;
public class GetLeaveTypeListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    public GetLeaveTypeListRequestHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();

        result.Count.ShouldBe(2);
    }
}
