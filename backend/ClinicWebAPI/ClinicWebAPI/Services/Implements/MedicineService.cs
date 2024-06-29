using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Implements
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public MedicineService(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }
        public async Task<MedicineDto> AddOrUpdateAsync(MedicineDto medicine)
        {
            var m = _mapper.Map<Medicine>(medicine);
            if (medicine.Id != null)
            {
                m.Id = medicine.Id;
                m.UpdatedDate = DateTime.UtcNow;
            }
            else
            {
                m.CreatedDate = DateTime.UtcNow;
                m.UpdatedDate = DateTime.UtcNow;
            }
            var result = await _medicineRepository.AddOrUpdateAsync(m);
            return _mapper.Map<MedicineDto>(result);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _medicineRepository.DeleteAsync(id);
            return result;
        }

        public async Task<MedicineDto> FindByIdAsync(string id)
        {
            var medicine = await _medicineRepository.FindByIdAsync(id);
            return _mapper.Map<MedicineDto>(medicine);
        }

        public async Task<ICollection<MedicineDto>> FindByNameAsync(string name)
        {
            var list = await _medicineRepository.FindByNameAsync(name);
            return _mapper.Map<List<MedicineDto>>(list);
        }

        public async Task<ICollection<MedicineDto>> GetAllAsync()
        {
            var list = await _medicineRepository.GetAllAsync();
            return _mapper.Map<List<MedicineDto>>(list);
        }
    }
}
