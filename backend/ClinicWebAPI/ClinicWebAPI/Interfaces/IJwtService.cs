using ClinicWebAPI.Models;

namespace ClinicWebAPI.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
