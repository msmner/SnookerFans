using SnookerFans.Models;

namespace SnookerFans.Infrastructure.Repositories
{
    public interface IMatchRepository
    {
        Task<IList<Match>> GetAllByDateAsync();

        void Delete(Match match);

        Match Create(Match match);

        Task SaveChangesAsync();

        Task<Match?> GetByIdAsync(Guid id);

        Task<IList<Match>> GetMatchesByUsername(string userName);
    }
}
