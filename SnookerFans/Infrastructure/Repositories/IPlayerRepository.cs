using SnookerFans.Models;

namespace SnookerFans.Infrastructure.Repositories
{
    public interface IPlayerRepository
    {
        Task<IList<Player>> GetAllRanked();

        void Delete(Player player);

        Player Update(Player player);

        Player Create(Player player);

        Task SaveChangesAsync();

        Task<Player?> GetByUserNameAsync(string userName);
    }
}
