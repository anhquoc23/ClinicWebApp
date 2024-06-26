using ClinicWebAPI.Dtos;
using ClinicWebAPI.Models;

namespace ClinicWebAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Dictionary<string, string> keywords);
        Task<User> FindByUserNameAsync(string userName);
        Task<UserDto> FindByIdAsync(string id);
        Task<UserDto> AddAsync(UserDto user, string password, string role);
        Task<UserDto> UpdateAsync(UpdateUserDto user);
        Task<bool> DeleteAsync(string id);
    }
}
