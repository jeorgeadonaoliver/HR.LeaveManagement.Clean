using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypesVM>> GetLeaveTypes();

    Task<LeaveTypesVM> GetLeaveTypeDetails(int id);

    Task<Response<Guid>> CreateLeaveType(LeaveTypesVM leaveType);

    Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypesVM leaveType);

    Task<Response<Guid>> DeleteLeaveType(int id);

}





