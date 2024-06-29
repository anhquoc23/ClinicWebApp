using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface IMedicineService
    {
        Task<MedicineDto> AddOrUpdateAsync(MedicineDto medicine);
        Task<ICollection<MedicineDto>> GetAllAsync();
        Task<ICollection<MedicineDto>> FindByNameAsync(string name);
        Task<MedicineDto> FindByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}
