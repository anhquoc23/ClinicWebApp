using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DataContext _dataContext;

        public SpecializationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddOrUpdateAsync(Specialization specialization)
        {
            var s = await _dataContext.Specializations.FindAsync(specialization.Id);
            if (s == null)
            {
                await _dataContext.Specializations.AddAsync(specialization);
            } else
            {
                _dataContext.Entry(s).CurrentValues.SetValues(specialization);
            }
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ICollection<Specialization>> GetAllAsync()
        {
            var result = await _dataContext.Specializations.Where(s => s.IsActive).ToListAsync();
            return result;
        }
    }
}
