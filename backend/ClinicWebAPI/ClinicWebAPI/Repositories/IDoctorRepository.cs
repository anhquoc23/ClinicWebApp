using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface IDoctorRepository
    {
        Task<Boolean> AddOrUpdateAsync(Doctor doctor);
        Task<ICollection<Doctor>> GetAllAsync();
        Task<Doctor> FindByIdAsync(string id);
    }
}
