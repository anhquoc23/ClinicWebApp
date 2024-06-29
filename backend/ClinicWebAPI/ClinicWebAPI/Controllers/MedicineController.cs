using ClinicWebAPI.Attributes;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ClinicWebAPI.Controllers
{
    [Route("api/medicine")]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string ?name)
        {
            ICollection<MedicineDto> list;
            if (name.IsNullOrEmpty())
            {
                list = await _medicineService.GetAllAsync();
            }
            else
            {
                list = await _medicineService.FindByNameAsync(name); 
            }
            return Ok(list);
        }

        [HttpPost("addorchange/")]
        [Authorization("ADMIN")]
        public async Task<IActionResult> AddOrUpdate([FromBody] MedicineDto? medicineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicine = await _medicineService.AddOrUpdateAsync(medicineDto);
            if (medicine == null)
            {
                ModelState.AddModelError(string.Empty, "Có Lỗi Xảy Ra, Vui Lòng Thử Lại");
                return BadRequest(ModelState);
            }
            return StatusCode(201, medicine);
        }

        [HttpDelete("delete/{id}/")]
        [Authorization("ADMIN")]
        public async Task<IActionResult> Delete(string id)
        {
            var medicine = await _medicineService.FindByIdAsync(id);
            if (medicine == null)
            {
                return BadRequest("Có Lỗi Xảy ra.");
            }
            var result = await _medicineService.DeleteAsync(id);
            return result ? NoContent() : BadRequest("Có Lỗi Xảy ra.");
        }
    }
}
