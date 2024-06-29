using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly DataContext _dataContext;

        public MedicineRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Medicine> AddOrUpdateAsync(Medicine medicine)
        {
            var m = await _dataContext.Medicines.FindAsync(medicine.Id);
            if (m == null)
            {
                await _dataContext.Medicines.AddAsync(medicine);
            }
            else
            {
                medicine.CreatedDate = m.CreatedDate;
                _dataContext.Entry(m).CurrentValues.SetValues(medicine);
            }
            var result = await _dataContext.SaveChangesAsync();
            return result > 0 ? medicine : null;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var m = await _dataContext.Medicines.FindAsync(id);
            if (m != null)
            {
                m.IsActive = false;
                var state = _dataContext.Medicines.Attach(m);
                state.State = EntityState.Modified;
                var result = await _dataContext.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

        public async Task<Medicine> FindByIdAsync(string id)
        {
            return await _dataContext.Medicines.FindAsync(id);
        }

        public async Task<ICollection<Medicine>> FindByNameAsync(string name)
        {
            var list = await _dataContext.Medicines.Where(u => u.IsActive && u.Name.Contains(name))
                                                    .OrderBy(u => u.Name).ThenBy(u => u.CreatedDate)
                                                    .ToListAsync();
            return list;
        }

        public async Task<ICollection<Medicine>> GetAllAsync()
        {
            var list = await _dataContext.Medicines.Where(u => u.IsActive).OrderBy(u => u.Name).ThenBy(u => u.CreatedDate).ToListAsync();
            return list;
        }
    }
}
