using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface IScheduleService
    {
        Task<ScheduleViewDto> CreateAsync(ScheduleViewDto schedule);
        Task<ICollection<ScheduleViewDto>> GetAllAsync(DateTime dateTime);
    }
}
