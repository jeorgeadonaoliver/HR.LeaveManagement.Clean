﻿using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Validators;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._leaveRequestRepository = leaveRequestRepository;

        Include(new BaseLeaveRequestValidator(_leaveTypeRepository));


        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveRequestMustExist)
            .WithMessage("{PropertyName must be present.}");
    }

    public async Task<bool> LeaveRequestMustExist(int id, CancellationToken cancellation) { 
    
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

        return leaveRequest != null;
    }
}
