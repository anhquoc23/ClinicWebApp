using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> CreateAsync(Schedule schedule);
        Task<ICollection<Schedule>> GetAllAsync(DateTime dateTime);
    }
}
