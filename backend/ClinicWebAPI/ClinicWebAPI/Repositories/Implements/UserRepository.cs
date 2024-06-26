
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

        public async Task<User> AddAsync(User user, string password, string? role)
        {
            var u = await _dataContext.Users.FindAsync(user.Id);
            if (u == null)
            {
                await _userManager.CreateAsync(user, password);
                await _userManager.AddToRoleAsync(user, role);
                return user;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await this._dataContext.Users.FindAsync(id);
            if (user != null)
            {
                Console.WriteLine("____________________________________");
                Console.WriteLine(user.UserName);
                var lockoutEndDate = DateTime.UtcNow.AddYears(100);
                var result = await _userManager.SetLockoutEndDateAsync(user, lockoutEndDate);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _dataContext.Users.FindAsync(id);
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

        public async Task<User> UpdateAsync(User user)
        {
            var u = await _dataContext.Users.FindAsync(user.Id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            u.Address = user.Address;
            var result = await _userManager.UpdateAsync(u);
            return result.Succeeded ? u : null;

        }
    }
}
