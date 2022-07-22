using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnookerFans.Dtos;
using SnookerFans.Models;
using SnookerFans.Services;

namespace SnookerFans.Controllers
{
    [Produces("application/json")]
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchesController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<MatchDto>> Create(CreateMatchDto createMatchDto)
        {
            Match match = await _matchService.Create(createMatchDto);
            var matchDto = _mapper.Map<MatchDto>(match);

            return matchDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _matchService.Delete(id);

            return NoContent();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "user")]
        public async Task<IList<MatchDto>> GetMatchesByDateDesc()
        {
            IList<Match> matches = await _matchService.GetAllMatchesByDateDesc();
            var matchesDto = _mapper.Map<IList<MatchDto>>(matches);

            return matchesDto;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "user")]
        public async Task<MatchDto> GetMatch(Guid id)
        {
            Match? match = await _matchService.GetMatch(id);
            var matchDto = _mapper.Map<MatchDto>(match);

            return matchDto;
        }
    }
}
