using SnookerFans.Dtos;
using SnookerFans.Exceptions;
using SnookerFans.Infrastructure.Repositories;
using SnookerFans.Models;

namespace SnookerFans.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMatchService _matchService;
        private readonly IMatchRepository _matchRepository;
        public PlayerService(IPlayerRepository playerRepository, IMatchService matchService, IMatchRepository matchRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
            _matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));

        }

        public async Task<Player> Create(CreatePlayerDto createPlayerDto)
        {
            Player? checkUsername = await _playerRepository.GetByUserNameAsync(createPlayerDto.UserName);
            if (checkUsername != null)
            {
                throw new UsernameAlreadyExistsException();
            }

            Player player = new()
            {
                UserName = createPlayerDto.UserName,
                Nationality = createPlayerDto.Nationality,
                PlayerOneMatches = new List<Match>(),
                PlayerTwoMatches = new List<Match>(),
                CreatedOn = DateTime.Now,
                Description = createPlayerDto.Description,
            };

            _playerRepository.Create(player);
            await _playerRepository.SaveChangesAsync();

            return player;
        }

        public async Task Delete(string userName)
        {
            Player? player = await _playerRepository.GetByUserNameAsync(userName);
            if (player == null)
            {
                throw new PlayerNotFoundException();
            }

            for (int i = player.PlayerOneMatches.Count - 1; i >= 0; i--)
            {
                await _matchService.Delete(id: player.PlayerOneMatches.ToList()[i].Id);
            }

            for (int i = player.PlayerTwoMatches.Count - 1; i >= 0; i--)
            {
                await _matchService.Delete(id: player.PlayerTwoMatches.ToList()[i].Id);
            }

            _playerRepository.Delete(player);
            await _playerRepository.SaveChangesAsync();
        }

        public async Task<Player> GetPlayer(string userName)
        {
            Player? player = await _playerRepository.GetByUserNameAsync(userName);
            if (player == null)
            {
                throw new PlayerNotFoundException();
            }

            return player;
        }

        public async Task<IList<Player>> GetPlayersRanked()
        {
            return await _playerRepository.GetAllRanked();
        }

        public async Task<Player> Update(string userName, UpdatePlayerDto updatePlayerDto)
        {
            Player? player = await _playerRepository.GetByUserNameAsync(userName);
            if (player == null)
            {
                throw new PlayerNotFoundException();
            }

            Player? checkUsername = await _playerRepository.GetByUserNameAsync(updatePlayerDto.UserName);
            if (checkUsername != null)
            {
                throw new UsernameAlreadyExistsException();
            }

            player.UserName = updatePlayerDto.UserName;
            player.Nationality = updatePlayerDto.Nationality;
            player.Description = updatePlayerDto.Description;

            _playerRepository.Update(player);
            await _playerRepository.SaveChangesAsync();

            return player;
        }

        public async Task<IList<Match>> GetMatchesByPlayer(string username)
        {
            return await _matchRepository.GetMatchesByUsername(username);
        }
    }
}
