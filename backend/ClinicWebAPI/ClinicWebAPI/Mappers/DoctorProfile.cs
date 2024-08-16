using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Mappers
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile() 
        { 
            CreateMap<Doctor, DoctorDto>().ForMember(des => des.FirstName, act => act.MapFrom(src => src.User.FirstName))
                                            .ForMember(des => des.LastName, act => act.MapFrom(src => src.User.LastName));
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
