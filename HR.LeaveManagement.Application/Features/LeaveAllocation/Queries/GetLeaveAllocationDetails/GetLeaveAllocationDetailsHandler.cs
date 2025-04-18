using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
    {
        ILeaveAllocationRepository _leaveAllocationRepository;
        IMapper _mapper;

        public GetLeaveAllocationDetailsHandler(ILeaveAllocationRepository leaveAllocation, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocation;
            this._mapper = mapper;
        }
        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            var result = _mapper.Map<LeaveAllocationDetailsDto>(data);

            return result;

        }
    }
}
