using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails;
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

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveType.Queries
{
    public class GetLeaveTypeDetailQueryHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;

        public GetLeaveTypeDetailQueryHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c => {

                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeDetailQueryTest()
        {
            var handler = new GetLeaveTypeDetailQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetLeaveTypeDetailQuery(2),CancellationToken.None);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(2);
            result.Name.ShouldBe("Test Sick");
            
        }
    }
}
