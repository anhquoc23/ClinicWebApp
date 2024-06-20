using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories;

namespace ClinicWebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddOrUpdateAsync(UserDto user, string password, string role)
        {
            var u = _mapper.Map<User>(user);
            return await _userRepository.AddOrUpdateAsync(u, password, role);
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _userRepository.FindByUserNameAsync(userName);
        }

        public async Task<User> GetUser(Dictionary<string, string> keywords)
        {
            return await _userRepository.GetUser(keywords);
        }
    }
}
