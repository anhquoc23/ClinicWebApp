using ClinicWebAPI.Attributes;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    [Authorize]
    [Route("api/specialization")]
    public class SpecializationController : Controller
    {
        private readonly ISpecializationService _specializationService;
        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var result = await _specializationService.GetAllAsync();
            return Ok(result);
        }

        [Authorization("ADMIN")]
        [HttpPost("add/")]
        public async Task<IActionResult> AddOrUpdateAsync([FromBody] Specialization specialization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _specializationService.AddOrUpdateAsync(specialization);
            if (result)
                return Ok(specialization);
            return BadRequest("Cannot Add Or Update This Object");
        }
    }
}
