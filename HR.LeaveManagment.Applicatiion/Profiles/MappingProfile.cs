using AutoMapper;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveAllocation;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveRequest;
using HR.LeaveManagment.Applicatiion.DTOs.LeaveType;
using HR.LeaveManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Applicatiion.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
           

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationListDto>().ReverseMap();

        }
    }
}
