using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdateAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Doctor> FindByIdAsync(string id)
        {
            var result = await _context.Doctors.FindAsync(id);
            return result;
        }

        public async Task<ICollection<Doctor>> GetAllAsync()
        {
            var result = await _context.Doctors.Include(doctor => doctor.Specialization).Include(doctor => doctor.User).ToListAsync();
            return result;
        }
    }
}
