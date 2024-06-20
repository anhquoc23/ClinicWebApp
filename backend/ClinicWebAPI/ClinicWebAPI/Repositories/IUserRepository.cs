using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(Dictionary<string, string> keywords);
        Task<User> FindByUserNameAsync(string userName);
        
    }
}
