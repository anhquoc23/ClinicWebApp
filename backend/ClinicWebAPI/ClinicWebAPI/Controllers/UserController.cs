using ClinicWebAPI.Attributes;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Interfaces;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services;
using ClinicWebAPI.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicWebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, SignInManager<User> signInManager, IJwtService jwtService, ICloudinaryService cloudinaryService, IRoleService roleService)
        {
            _userService = userService;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _cloudinaryService = cloudinaryService;
            _roleService = roleService;
        }

        [HttpPost("token/")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetToken([FromBody] LoginDto loginUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.FindByUserNameAsync(loginUser.Username);
            if (user == null) return Unauthorized("Username không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, true, false);
            return result.Succeeded ? Ok(_jwtService.CreateToken(user)) : BadRequest("Mật Khẩu Không Chính Xác");

        }

        [HttpGet("current-user/")]
        [Authorize]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var username = User.Identity.Name;
            var user = await _userService.FindByUserNameAsync(username);
            return Ok(user);
        }

        [HttpPost("addpatient/")]
        public async Task<IActionResult> AddPatient([FromQuery] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cloudinaryService.UploadPhotoToCloudinaryAsync(user.Image);
            user.Avatar = result.Url.ToString();
            var addResult = await _userService.AddAsync(user, user.Password, Models.User.UserRole["PATIENT"]);

            return addResult != null ? StatusCode(201, "Thêm Thành Công") : StatusCode(404, ModelState);
        }

        [HttpPost("addemployee/{role}/")]
        [Authorization("ADMIN")]
        public async Task<IActionResult> AddEmpoyee([FromQuery] UserDto user, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cloudinaryService.UploadPhotoToCloudinaryAsync(user.Image);
            user.Avatar = result.Url.ToString();
            var addResult = await _userService.AddAsync(user, user.Password, role);

            return addResult != null ? StatusCode(201, "Thêm Thành Công") : StatusCode(404, ModelState);
        }

        [HttpGet("{id}/")]
        [Authorize]
        public async Task<IActionResult> Detail(string id)
        {
            var userDto = await _userService.FindByIdAsync(id);
            return StatusCode(200, userDto);
        }

        [HttpPut("edit/{id}/")]
        [Owner]
        public async Task<IActionResult> Edit(string id, [FromBody] UpdateUserDto userInfoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var u = await _userService.FindByIdAsync(id);
            if (u == null)
                return NotFound("Not Found User");
            var user = await _userService.UpdateAsync(userInfoDto);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("delete/{id}/")]
        [Owner]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.DeleteAsync(id);
            return result ? NoContent() : BadRequest("User Is Not Correct");
        }
    }
}
