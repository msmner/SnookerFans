using SnookerFans.Dtos;
using SnookerFans.Models;

namespace SnookerFans.Services
{
    public interface IAccountService
    {
        Task<User> Register(RegisterDto userDto);

        Task<User> Login(LoginDto loginDto);
    }
}
