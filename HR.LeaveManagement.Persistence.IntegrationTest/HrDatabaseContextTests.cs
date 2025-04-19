using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTest;

public class HrDatabaseContextTests
{
    private readonly HrDatabaseContext _hrDatabaseContext;

    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


        _hrDatabaseContext = new HrDatabaseContext(dbOptions);
    }
    [Fact]
    public async void Save_SetDateCreatedValue()
    {
        var leaveTypes = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        //Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(leaveTypes);
        await _hrDatabaseContext.SaveChangesAsync();

        //Assert
        leaveTypes.DateCreated.ShouldNotBeNull();

    }

    [Fact]
    public async void Save_SetDateModifiedValue()
    {
        var leaveTypes = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };

        //Act
        await _hrDatabaseContext.LeaveTypes.AddAsync(leaveTypes);
        await _hrDatabaseContext.SaveChangesAsync();

        //Assert
        leaveTypes.DateModified.ShouldNotBeNull();

    }
}