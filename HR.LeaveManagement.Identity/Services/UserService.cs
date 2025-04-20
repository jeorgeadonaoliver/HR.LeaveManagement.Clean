using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagement.Identity.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace HR.LeaveManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        this._userManager = userManager;
    }
    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        return new Employee() 
        {
            Email = employee.Email,
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
        throw new NotImplementedException();
    }

    public async Task<List<Employee>> GetEmployees()
    {

        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        return employees.Select(q => new Employee() 
        {
            Id = q.Id,
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
        throw new NotImplementedException();
    }
}
