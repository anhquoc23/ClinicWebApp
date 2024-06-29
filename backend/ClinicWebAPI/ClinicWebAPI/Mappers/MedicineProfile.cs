using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Mappers
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineDto, Medicine>().ForMember(des => des.Id, opt => opt.Ignore());
        }
    }
}
