using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface IMedicineRepository
    {
        Task<Medicine> AddOrUpdateAsync(Medicine medicine);
        Task<ICollection<Medicine>> GetAllAsync();
        Task<ICollection<Medicine>> FindByNameAsync(string name);
        Task<Medicine> FindByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}
