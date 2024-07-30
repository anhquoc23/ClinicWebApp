using ClinicWebAPI.Attributes;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    [Route("api/schedule/")]
    [Authorize]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(DateTime ?query)
        {
            if (query == null)
                query = DateTime.Now;
            var schedules = await _scheduleService.GetAllAsync((DateTime)query);
            return Ok(schedules);
        }

        [HttpPost("add/")]
        [Authorization("ADMIN")]
        public async Task<IActionResult> Add([FromBody] ScheduleViewDto? schedule)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _scheduleService.CreateAsync(schedule);
            return StatusCode(201, result);

        }
    }
}
