using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Mappers
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleViewDto>().ForMember(des => des.TimeStart, act => act.MapFrom(src => src.Shift.TimeStart))
                                                    .ForMember(des => des.TimeEnd, act => act.MapFrom(src => src.Shift.TimeEnd))
                                                    .ForMember(des => des.EmployeeName, act => act.MapFrom(src => $"{src.User.FirstName} ${src.User.LastName}"));
            CreateMap<ScheduleViewDto, Schedule>();
        }
    }
}
