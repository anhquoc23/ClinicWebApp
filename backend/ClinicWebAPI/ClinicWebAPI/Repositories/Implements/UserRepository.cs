
using ClinicWebAPI.Configs;
using ClinicWebAPI.Data.Enum;
using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
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

        public async Task<int> CountUserAsync()
        {
            return await _dataContext.Users.Where(user => user.LockoutEnd == null).CountAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = await this._dataContext.Users.FindAsync(id);
            if (user != null)
            {
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

        public async Task<ICollection<User>> FindByNameAsync(string name, int page = 1)
        {
            return await _dataContext.Users.Where(user => user.LockoutEnd == null 
                                                && (user.FirstName.Contains(name) || user.LastName.Contains(name)))
                                                .Skip((page - 1) * StaticEnum.PAGE_SIZE).Take(StaticEnum.PAGE_SIZE)
                                                .ToListAsync();
        }

        public async Task<ICollection<User>> FindByRoleAsync(string role, int page = 1)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return users.Skip((page - 1) * StaticEnum.PAGE_SIZE).Take(StaticEnum.PAGE_SIZE).ToList();
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }

        public async Task<ICollection<User>> GetAllAsync(int page = 1)
        {
            var users = await _dataContext.Users.Where(user => user.LockoutEnd == null)
                                                .Take(StaticEnum.PAGE_SIZE).Skip((page - 1) * StaticEnum.PAGE_SIZE)
                                                .ToListAsync();
            return users;
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
