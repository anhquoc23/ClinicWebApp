using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Dictionary<string, string> keywords);
        Task<User> FindByUserNameAsync(string userName);
        Task<bool> AddOrUpdateAsync(UserDto user, string password, string role);
    }
}
