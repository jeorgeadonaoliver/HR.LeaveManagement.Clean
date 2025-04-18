using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveType.Commands;


public class CreateLeaveTypeCommandHandlerTest
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandlerTest()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c => {

            c.AddProfile<LeaveTypeProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateLeaveTypeCommandTest() 
    {
        var handler = new CreateLeaveTypeCommandHandler(_mapper,_mockRepo.Object);

        var leaveTypeCommand = new CreateLeaveTypeCommand {
            Name = "Birthday Leave",
            DefaultDays = 3
        };

        try
        {
            var result = await handler.Handle(leaveTypeCommand, CancellationToken.None);

            _mockRepo.Verify(r => r.CreateAsync(It.IsAny<Domain.LeaveType>()));

        }
        catch (BadRequestException ex)
        {
            // Log or inspect what went wrong
            Console.WriteLine("Validation failed:");
            foreach (var error in ex.ValidationErros)
            {
                Console.WriteLine($"{error.Key}: {error.Value}");
            }

            throw; // rethrow to not suppress test failure
        }


    }
}
