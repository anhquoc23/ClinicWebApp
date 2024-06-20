﻿using ClinicWebAPI.Dtos;
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
        private readonly ICloudinaryService _cloudinaryService;

        public UserController(IUserService userService, SignInManager<User> signInManager, IJwtService jwtService, ICloudinaryService cloudinaryService)
        {
            _userService = userService;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _cloudinaryService = cloudinaryService;
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
            Console.WriteLine("test");
            Console.WriteLine(username);
            if (username == null || username == "")
            {
                Console.WriteLine("Lỗi Username");
            }
            var user = await _userService.FindByUserNameAsync(username);
            return Ok(user);
        }

        [HttpPost("addorchange/")]
        public async Task<IActionResult> AddPatient([FromQuery] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cloudinaryService.UploadPhotoToCloudinaryAsync(user.Image);
            user.Avatar = result.Url.ToString();
            User userRegister = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Avatar = user.Avatar,
                Address = user.Address
            };
            var addResult = await _userService.AddOrUpdateAsync(userRegister, user.Password, Models.User.UserRole["PATIENT"]);

            return addResult ? Ok(userRegister) : BadRequest(ModelState);
        }
    }
}
