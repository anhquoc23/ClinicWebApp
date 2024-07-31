using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface ISpecializationService
    {
        Task<ICollection<Specialization>> GetAllAsync();
        Task<Boolean> AddOrUpdateAsync(Specialization specialization);
    }
}
