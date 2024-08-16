using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Implements
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _docRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddOrUpdateAsync(Doctor doctor)
        {
            return await _docRepository.AddOrUpdateAsync(doctor);
        }

        public Task<Doctor> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DoctorDto>> GetAllAsync()
        {
            var result = await _docRepository.GetAllAsync();
            return _mapper.Map<ICollection<DoctorDto>>(result);
            
        }
    }
}
