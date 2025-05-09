﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public UpdateLeaveAllocationCommandValidator(
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
            this._leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must greater than {ComparisonValue}");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveAllocationMustExist)
                .WithMessage("{PropertyName} must be present.");
        }

        private async Task<bool> LeaveAllocationMustExist(int id, CancellationToken token)
        {
            var IsExist = await _leaveAllocationRepository.GetByIdAsync(id);
            return IsExist != null;
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken) { 
        
            var IsExist = await _leaveTypeRepository.GetByIdAsync(id);
            return IsExist != null;
        }
    }
}
