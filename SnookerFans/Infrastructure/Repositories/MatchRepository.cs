using Microsoft.EntityFrameworkCore;
using SnookerFans.Models;

namespace SnookerFans.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly SnookerDbContext _context;

        public MatchRepository(SnookerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public Match Create(Match match)
        {
            return _context.Matches.Add(match).Entity;
        }

        public void Delete(Match match)
        {
            _context.Matches.Remove(match);

            return;
        }

        public async Task<IList<Match>> GetMatchesByUsername(string userName)
        {
            return await _context.Matches.Include(m => m.PlayerOne).Include(m => m.PlayerTwo).Where(x => x.PlayerOne.UserName.ToLower() == userName.ToLower() || x.PlayerTwo.UserName.ToLower() == userName.ToLower()).ToListAsync();
        }

        public async Task<IList<Match>> GetAllByDateAsync()
        {
            return await _context.Matches.Include(m => m.PlayerOne).Include(m => m.PlayerTwo).OrderByDescending(m => m.CreatedOn).ToListAsync();
        }

        public async Task<Match?> GetByIdAsync(Guid id)
        {
            return await _context.Matches.Include(x => x.PlayerOne).Include(y => y.PlayerTwo).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
