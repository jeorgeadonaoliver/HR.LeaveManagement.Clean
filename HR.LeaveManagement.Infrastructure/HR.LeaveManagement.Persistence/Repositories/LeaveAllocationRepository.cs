using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, 
        ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddLeaveAllocation(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocation
                .Include(q => q.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocationByUser = await _context.LeaveAllocation
                .Where(q => q.EmployeeId == userId)
                .ToListAsync();

            return leaveAllocationByUser;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _context.LeaveAllocation
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocation.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                            && q.LeaveTypeId == leaveTypeId);
        }

        public async Task<bool> LeaveAllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocation.AnyAsync(q => q.EmployeeId == userId
                                && q.LeaveTypeId == leaveTypeId
                                && q.Period == period);
        }
    }
}
