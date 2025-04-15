using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{

    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLoggers<UpdateLeaveTypeCommandHandler> _appLoggers;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepository,
            IAppLoggers<UpdateLeaveTypeCommandHandler> appLoggers)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository; 
            this._appLoggers = appLoggers; 
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            //validate incoming data
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Any())
            {
                _appLoggers.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(LeaveType), request.Id);

                throw new BadRequestException("Invalid Leave Type ", validatorResult);
            }

            //convert to domain entity object
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            //add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            //return unit value

            return Unit.Value;

        }

        private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
