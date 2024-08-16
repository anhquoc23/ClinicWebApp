using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface IDoctorService
    {
        Task<Boolean> AddOrUpdateAsync(Doctor doctor);
        Task<ICollection<DoctorDto>> GetAllAsync();
        Task<Doctor> FindByIdAsync(string id);
    }
}
