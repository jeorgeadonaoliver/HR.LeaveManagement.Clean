using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails
{
    public class GetLeaveTypeDetailQueryHandler: IRequestHandler<GetLeaveTypeDetailQuery,LeaveTypeDetailDto>
    {
        IMapper _mapper;
        ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository) 
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<LeaveTypeDetailDto>(leaveTypeDetails);

            return data;
        }
    }
}
