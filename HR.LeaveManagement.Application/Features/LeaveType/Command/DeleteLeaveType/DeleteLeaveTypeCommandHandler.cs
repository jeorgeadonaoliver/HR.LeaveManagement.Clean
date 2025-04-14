﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //convert to domain entity
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify that record exist
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            //remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete.Id);

            return Unit.Value;
        }
    }
}
