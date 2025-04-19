using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Models.Mapping_Profiles
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypesVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypesVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypesVM>().ReverseMap();
        }
    }
}
