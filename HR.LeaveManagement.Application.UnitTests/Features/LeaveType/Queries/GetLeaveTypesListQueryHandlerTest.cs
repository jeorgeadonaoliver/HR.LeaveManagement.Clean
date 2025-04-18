using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveType.Queries;

public class GetLeaveTypesListQueryHandlerTest
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLoggers<GetLeaveTypesQueryHandler>> _mockappLogger;

    public GetLeaveTypesListQueryHandlerTest()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration( c => {

            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockappLogger = new Mock<IAppLoggers<GetLeaveTypesQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypeListTest() 
    {
        var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockappLogger.Object );

        var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(5);
    }
}
