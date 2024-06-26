using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;
using ClinicWebAPI.Repositories.Identity;

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

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _userRepository.FindByUserNameAsync(userName);
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
