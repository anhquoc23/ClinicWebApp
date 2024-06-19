
using ClinicWebAPI.Configs;
using ClinicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebAPI.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
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
