using ClinicWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _dctorService;
        public DoctorController(IDoctorService dctorService)
        {
            _dctorService = dctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _dctorService.GetAllAsync();
            return Ok(result);
        }
    }
}
