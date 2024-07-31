using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Implements
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _repository;
        public SpecializationService(ISpecializationRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddOrUpdateAsync(Specialization specialization)
        {
            return await _repository.AddOrUpdateAsync(specialization);
        }

        public async Task<ICollection<Specialization>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
