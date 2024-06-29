using AutoMapper;
using ClinicWebAPI.Attributes;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services;
using ClinicWebAPI.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    [Route("api/admin")]
    [Authorization("ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPut("user/edit/{id}/")]
        public async Task<IActionResult> EditByAdmin(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var userDto = await _userService.FindByIdAsync(id);
            var roles = await _roleService.FindByUser(_mapper.Map<User>(userDto));
            if (roles.Contains("PATIENT"))
                return StatusCode(403, "You Can't Edit Patient");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var u = await _userService.FindByIdAsync(id);
            if (u == null)
                return NotFound("Not Found User");
            var user = await _userService.UpdateAsync(updateUserDto);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("user/delete/{id}/")]
        public async Task<IActionResult> DeleteByAdmin(string id)
        {
            var userDto = await _userService.FindByIdAsync(id);
            var roles = await _roleService.FindByUser(_mapper.Map<User>(userDto));
            if (roles.Contains("PATIENT"))
                return StatusCode(403, "You Can't Edit Patient");
            var result = await _userService.DeleteAsync(id);
            return result ? NoContent() : BadRequest("User Is Not Correct");
        }
    }
}
