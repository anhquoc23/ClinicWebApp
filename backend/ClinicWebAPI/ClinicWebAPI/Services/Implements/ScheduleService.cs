using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Implements
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }
        public async Task<ScheduleViewDto> CreateAsync(ScheduleViewDto schedule)
        {
            var sche = _mapper.Map<Schedule>(schedule);
            var result = await _scheduleRepository.CreateAsync(sche);
            return result != null ? _mapper.Map<ScheduleViewDto>(result) : null;
        }

        public async Task<ICollection<ScheduleViewDto>> GetAllAsync(DateTime dateTime)
        {
            var result = await _scheduleRepository.GetAllAsync(dateTime);
            return _mapper.Map<ICollection<ScheduleViewDto>>(result);
        }
    }
}
