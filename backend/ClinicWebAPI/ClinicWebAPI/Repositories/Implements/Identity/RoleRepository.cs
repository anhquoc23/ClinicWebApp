using ClinicWebAPI.Models;
using ClinicWebAPI.Repositories.Identity;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;

namespace ClinicWebAPI.Repositories.Implements.Identity
{
    public class RoleRepository : IRoleRepository
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this._roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<bool> AddRole(string roleName)
        {
            if (!await this._roleManager.RoleExistsAsync(roleName))
            {
                await this._roleManager.CreateAsync(new IdentityRole(roleName));
                return true;
            }
            return false;
        }

        public async Task<List<string>> FindByUser(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }

        public async Task<bool> IsInRole(User user, string role)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var listRoles = roles.ToList();
            return listRoles.Contains(role);
        }
    }
}
