

using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        { 
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>().ForMember(des => des.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber));
            CreateMap<UpdateUserDto, User>().ForMember(des => des.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber));
        }
    }
}
