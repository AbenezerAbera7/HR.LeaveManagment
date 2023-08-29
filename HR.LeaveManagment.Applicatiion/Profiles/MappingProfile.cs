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
            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion LeaveType

            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest

            #region LeaveAllocation
            CreateMap<LeaveType, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveAllocationListDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, UpdateLeaveAllocationDto>().ReverseMap();
            #endregion LeaveAllocation

        }
    }
}
