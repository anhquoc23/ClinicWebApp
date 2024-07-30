using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace ClinicWebAPI.Repositories.Implements
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _dataContext;

        public ScheduleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Schedule> CreateAsync(Schedule schedule)
        {
            await _dataContext.Schedules.AddAsync(schedule);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0 ? schedule : null;
        }

        public async Task<ICollection<Schedule>> GetAllAsync(DateTime dateTime)
        {
            if (dateTime == null)
                dateTime = DateTime.Now;

            var schedules = await _dataContext.Schedules.Where(schedule => schedule.DateShift.Date == dateTime.Date)
                                    .OrderBy(o => o.Shift.TimeStart)
                                    .Include(user => user.User).Include(room => room.Room).Include(shift => shift.Shift)
                                    .ToListAsync();
            return (ICollection<Schedule>)schedules;
        }
    }
}
