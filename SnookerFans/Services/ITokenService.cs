using SnookerFans.Models;

namespace SnookerFans.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
