using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;
using ClinicWebAPI.Repositories.Identity;
using CloudinaryDotNet.Actions;

namespace ClinicWebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> AddAsync(UserDto user, string password, string role)
        {
            var u = _mapper.Map<User>(user);
            var result = await _userRepository.AddAsync(u, password, role);
            return result == null ? null : _mapper.Map<UserDto>(result);
        }

        public async Task<int> CountUserAsync()
        {
            return await _userRepository.CountUserAsync();
        }

        public Task<bool> DeleteAsync(string id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> FindByIdAsync(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            Console.WriteLine("------------------------role----------------");
            var roles = await _roleRepository.FindByUser(user);
            foreach (var role in roles)
            {
                Console.WriteLine(role);
            }
            Console.WriteLine("------------------------end role----------------");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<ICollection<UserDto>> FindByNameAsync(string name, int page = 1)
        {
            var users = await _userRepository.FindByNameAsync(name, page);
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<ICollection<UserDto>> FindByRoleAsync(string role, int page = 1)
        {
            var users = await _userRepository.FindByRoleAsync(role, page);
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _userRepository.FindByUserNameAsync(userName);
        }

        public async Task<ICollection<UserDto>> GetAllAsync(int page = 1)
        {
            var users = await _userRepository.GetAllAsync(page);
            var userDtos = _mapper.Map<ICollection<UserDto>>(users);
            return userDtos;
        }

        public async Task<User> GetUser(Dictionary<string, string> keywords)
        {
            return await _userRepository.GetUser(keywords);
        }

        public async Task<UserDto> UpdateAsync(UpdateUserDto user)
        {
            var u = _mapper.Map<User>(user);
            var result = await _userRepository.UpdateAsync(u);
            return result == null ? null : _mapper.Map<UserDto>(result);
        }
    }
}
