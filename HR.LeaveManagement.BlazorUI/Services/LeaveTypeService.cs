﻿using AutoMapper;
using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Services.Base;
using System.Linq.Expressions;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypesVM leaveType)
        {
            try 
            {
                await AddBearerToken();
                var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);

                return new Response<Guid>()
                {
                    Success = true
                };
            }
            catch(ApiException ex) 
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try 
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid> { Success = true };
            }
            catch(ApiException ex) 
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypesVM> GetLeaveTypeDetails(int id)
        {
            await AddBearerToken();
            var leaveTypes = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypesVM>(leaveTypes);
        }

        public async Task<List<LeaveTypesVM>> GetLeaveTypes()
        {
            await AddBearerToken();
            var leaveTypes = await _client.LeaveTypesAllAsync();

            return _mapper.Map<List<LeaveTypesVM>>(leaveTypes);
      }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypesVM leaveType)
        {
            try 
            {
                await AddBearerToken();
                var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommand);
                return new Response<Guid>()
                {
                    Success = true
                };
            }

            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
