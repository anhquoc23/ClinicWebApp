using AutoMapper;
using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories.Identity;
using ClinicWebAPI.Services.Identity;

namespace ClinicWebAPI.Services.Implements.Identity
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddRole(string roleName)
        {
            return await _roleRepository.AddRole(roleName);
        }

        public async Task<List<string>> FindByUser(User user)
        {
            return await _roleRepository.FindByUser(user);
        }

        public async Task<bool> IsInRole(User user, string role)
        {
            var u = _mapper.Map<User>(user);
            return await _roleRepository.IsInRole(u, role);
        }
    }
}
