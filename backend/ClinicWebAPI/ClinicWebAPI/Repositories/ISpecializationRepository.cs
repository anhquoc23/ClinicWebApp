using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface ISpecializationRepository
    {
        Task<ICollection<Specialization>>  GetAllAsync();
        Task<Boolean> AddOrUpdateAsync(Specialization specialization);
    }
}
