using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLoggers<GetLeaveTypesQueryHandler> _loggers;

        public GetLeaveTypesQueryHandler(IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepository,
            IAppLoggers<GetLeaveTypesQueryHandler> loggers)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._loggers = loggers;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //convert data objects to DTO 
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO Object
            return data;
        }
    }
}
