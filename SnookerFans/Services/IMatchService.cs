using SnookerFans.Dtos;
using SnookerFans.Models;

namespace SnookerFans.Services
{
    public interface IMatchService
    {
        Task<Match> Create(CreateMatchDto team);

        Task Delete(Guid id);

        Task<IList<Match>> GetAllMatchesByDateDesc();

        Task<Match?> GetMatch(Guid id);
    }
}
