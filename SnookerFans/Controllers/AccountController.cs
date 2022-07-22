using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnookerFans.Dtos;
using SnookerFans.Services;

namespace SnookerFans.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper, ITokenService tokenService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));

        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto registerDto)
        {
            var user = await _accountService.Register(registerDto);

            string token = await _tokenService.CreateToken(user);

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = token;

            return userDto;
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var user = await _accountService.Login(loginDto);

            string token = await _tokenService.CreateToken(user);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Token = token,
            };

            return userDto;
        }
    }
}
