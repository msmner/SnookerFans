using SnookerFans.Dtos;
using SnookerFans.Exceptions;
using SnookerFans.Infrastructure.Repositories;
using SnookerFans.Models;

namespace SnookerFans.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger<MatchService> _logger;
        public MatchService(IMatchRepository matchRepository, IPlayerRepository playerRepository, ILogger<MatchService> logger)
        {
            _matchRepository = matchRepository ?? throw new ArgumentNullException(nameof(matchRepository));
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        public async Task<Match> Create(CreateMatchDto createMatchDto)
        {
            Player? playerOne = await _playerRepository.GetByUserNameAsync(createMatchDto.PlayerOneUserName);
            Player? playerTwo = await _playerRepository.GetByUserNameAsync(createMatchDto.PlayerTwoUserName);
            if (playerOne == null || playerTwo == null)
            {
                throw new PlayerNotFoundException();
            }

            Match match = new()
            {
                PlayerOneId = playerOne.Id,
                PlayerOne = playerOne,
                PlayerTwoId = playerTwo.Id,
                PlayerTwo = playerTwo,
                PlayerOneMaximums = createMatchDto.PlayerOneMaximums,
                PlayerTwoMaximums = createMatchDto.PlayerTwoMaximums,
                Score = createMatchDto.Score,
                PlayerOneCenturyBreaks = createMatchDto.PlayerOneCenturyBreaks,
                PlayerOneHalfCenturyBreaks = createMatchDto.PlayerOneHalfCenturyBreaks,
                PlayerTwoCenturyBreaks = createMatchDto.PlayerTwoCenturyBreaks,
                PlayerTwoHalfCenturyBreaks = createMatchDto.PlayerTwoHalfCenturyBreaks,
                CreatedOn = DateTime.UtcNow,
                Description = createMatchDto.Description,
            };

            _matchRepository.Create(match);
            await _matchRepository.SaveChangesAsync();

            playerOne.CenturyBreaks += match.PlayerOneCenturyBreaks;
            playerOne.HalfCenturyBreaks += match.PlayerOneHalfCenturyBreaks;
            playerTwo.CenturyBreaks += match.PlayerTwoCenturyBreaks;
            playerTwo.HalfCenturyBreaks += match.PlayerTwoHalfCenturyBreaks;
            playerOne.LifeTimeMaximums += match.PlayerOneMaximums;
            playerTwo.LifeTimeMaximums += match.PlayerTwoMaximums;

            bool isPlayerOneWinner = IsWinner(match.Score);
            if (isPlayerOneWinner)
            {
                playerOne.Wins += 1;
            }
            else
            {
                playerTwo.Wins += 1;
            }
            // check if match is automatically added to player's matches

            await _playerRepository.SaveChangesAsync();

            return match;
        }

        public async Task Delete(Guid id)
        {
            Match? match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new MatchNotFoundException();
            }

            Player? playerOne = await _playerRepository.GetByUserNameAsync(match.PlayerOne.UserName);
            Player? playerTwo = await _playerRepository.GetByUserNameAsync(match.PlayerTwo.UserName);
            if (playerOne == null || playerTwo == null)
            {
                _logger.LogError($"Error finding the player with username {playerOne?.UserName} or {playerTwo?.UserName}");
                throw new PlayerNotFoundException();
            }

            bool isPlayerOneWinner = IsWinner(match.Score);
            if (isPlayerOneWinner)
            {
                playerOne.Wins -= 1;
            }
            else
            {
                playerTwo.Wins -= 1;
            }

            playerOne.LifeTimeMaximums -= match.PlayerOneMaximums;
            playerOne.CenturyBreaks -= match.PlayerOneCenturyBreaks;
            playerOne.HalfCenturyBreaks -= match.PlayerOneHalfCenturyBreaks;

            playerTwo.LifeTimeMaximums -= match.PlayerTwoMaximums;
            playerTwo.CenturyBreaks -= match.PlayerTwoCenturyBreaks;
            playerTwo.HalfCenturyBreaks -= match.PlayerTwoHalfCenturyBreaks;

            await _playerRepository.SaveChangesAsync();

            _matchRepository.Delete(match);
            await _matchRepository.SaveChangesAsync();
        }

        public async Task<IList<Match>> GetAllMatchesByDateDesc()
        {
            return await _matchRepository.GetAllByDateAsync();
        }

        public async Task<Match?> GetMatch(Guid id)
        {
            Match? match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new MatchNotFoundException();
            }

            return match;
        }

        private static bool IsWinner(string score)
        {
            string[] frames = score.Split(":", StringSplitOptions.RemoveEmptyEntries);
            return int.Parse(frames[0]) > int.Parse(frames[1]);
        }
    }
}
