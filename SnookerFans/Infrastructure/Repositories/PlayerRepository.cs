using Microsoft.EntityFrameworkCore;
using SnookerFans.Models;

namespace SnookerFans.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SnookerDbContext _context;

        public PlayerRepository(SnookerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public Player Create(Player player)
        {
            return _context.Players.Add(player).Entity;
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
        }

        public async Task<IList<Player>> GetAllRanked()
        {
            return await _context.Players.OrderByDescending(p => p.Wins).ToListAsync();
        }

        public async Task<Player?> GetByUserNameAsync(string userName)
        {
            return await _context.Players.Include(p => p.PlayerOneMatches).Include(p => p.PlayerTwoMatches).SingleOrDefaultAsync(p => p.UserName.ToLower() == userName.ToLower());
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Player Update(Player player)
        {
            return _context.Players.Update(player).Entity;
        }
    }
}
