using ClinicWebAPI.Repositories.Identity;
using Microsoft.AspNetCore.Identity;

namespace ClinicWebAPI.Repositories.Implements.Identity
{
    public class RoleRepository : IRoleRepository
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
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
    }
}
