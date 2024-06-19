using ClinicWebAPI.Dtos;
using ClinicWebAPI.Interfaces;
using ClinicWebAPI.Models;
using ClinicWebAPI.Services;
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

        public UserController(IUserService userService, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userService = userService;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("token")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetToken([FromBody] LoginDto loginUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dictionary<string, string> keyword = new Dictionary<string, string>
            {
                {"username", loginUser.Username},
            };
            var user = await _userService.GetUser(keyword);
            if (user == null) return Unauthorized("Username không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);
            return result.Succeeded ? Ok(_jwtService.CreateToken(user)) : BadRequest("Mật Khẩu Không Chính Xác");

        }

        [HttpGet("current-user")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var username = User.Identity.Name;
            Dictionary<string, string> keyword = new Dictionary<string, string>
            {
                {"username", username},
            };
            var user = await _userService.GetUser(keyword);
            return Ok(user);
        }

    }
}
