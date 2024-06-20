
using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(DataContext dataContext, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<bool> AddOrUpdateAsync(User user, string password, string? role)
        {
            var u = await _dataContext.Users.FindAsync(user.Id);
            if (u == null)
            {
                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }
            return false;
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }

        public async Task<User> GetUser(Dictionary<string, string> keywords)
        {
            if (keywords.ContainsKey("username")) {
                var user = await _dataContext.Users.Where(u => u.UserName.Equals(keywords["username"])).FirstOrDefaultAsync();
                return user;
            }
            return null;
        }
    }
}
