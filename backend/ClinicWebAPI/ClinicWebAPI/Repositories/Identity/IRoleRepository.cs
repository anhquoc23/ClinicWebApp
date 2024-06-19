namespace ClinicWebAPI.Repositories.Identity
{
    public interface IRoleRepository
    {
        Task<bool> AddRole(string roleName);
    }
}
