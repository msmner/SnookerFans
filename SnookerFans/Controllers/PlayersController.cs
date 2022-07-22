using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnookerFans.Dtos;
using SnookerFans.Models;
using SnookerFans.Services;

namespace SnookerFans.Controllers
{
    [Produces("application/json")]
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService ,IMapper mapper)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<PlayerDto>> Create(CreatePlayerDto createPlayerDto)
        {
            Player player = await _playerService.Create(createPlayerDto);
            var playerDto = _mapper.Map<PlayerDto>(player);

            return playerDto;
        }

        [HttpDelete("{username}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(string username)
        {
            await _playerService.Delete(username);

            return NoContent();
        }

        [HttpPut("{username}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Update(string username, UpdatePlayerDto updatePlayerDto)
        {
            await _playerService.Update(username, updatePlayerDto);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "user")]
        public async Task<IList<PlayerDto>> GetPlayersRanked()
        {
            IList<Player> players = await _playerService.GetPlayersRanked();
            IList<PlayerDto> playersDto = _mapper.Map<IList<PlayerDto>>(players);

            return playersDto;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "user")]
        public async Task<PlayerDto> GetPlayer(string username)
        {
            Player? players = await _playerService.GetPlayer(username);
            PlayerDto playerDto = _mapper.Map<PlayerDto>(players);

            return playerDto;
        }

        [HttpGet("{username}/matches")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "user")]
        public async Task<IList<MatchDto>> GetPlayersMatches(string username)
        {
            IList<Match> matches = await _playerService.GetMatchesByPlayer(username);
            IList<MatchDto> matchesDto = _mapper.Map<IList<MatchDto>>(matches);

            return matchesDto;
        }
    }
}
