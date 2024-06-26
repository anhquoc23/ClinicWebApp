using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services.Identity
{
    public interface IRoleService
    {
        Task<bool> AddRole(string roleName);
        Task<List<string>> FindByUser(User user);
        Task<bool> IsInRole(User user, string role);
    }
}
