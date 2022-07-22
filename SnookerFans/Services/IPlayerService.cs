using SnookerFans.Dtos;
using SnookerFans.Models;

namespace SnookerFans.Services
{
    public interface IPlayerService
    {
        Task<Player> Create(CreatePlayerDto player);

        Task Delete(string userName);

        Task<IList<Player>> GetPlayersRanked();

        Task<Player> Update(string userName, UpdatePlayerDto player);

        Task<Player> GetPlayer(string userName);

        Task<IList<Match>> GetMatchesByPlayer(string username);
    }
}
