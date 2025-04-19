using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Identity
{
    public class IUserService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string userId);
    }
}
