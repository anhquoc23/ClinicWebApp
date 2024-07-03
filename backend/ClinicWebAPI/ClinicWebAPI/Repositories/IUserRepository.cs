using ClinicWebAPI.Models;

namespace ClinicWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(Dictionary<string, string> keywords);
        Task<User> FindByUserNameAsync(string userName);
        Task<User> FindByIdAsync(string id);
        Task<User> AddAsync(User user, string password, string role);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(string id);
        Task<ICollection<User>> GetAllAsync(int page = 1);
        Task<ICollection<User>> FindByRoleAsync(string role, int page = 1);
        Task<ICollection<User>> FindByNameAsync(string name, int page = 1);
        Task<int> CountUserAsync();
        
    }
}
