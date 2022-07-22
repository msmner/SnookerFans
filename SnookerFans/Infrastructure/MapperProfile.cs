using SnookerFans.Dtos;
using SnookerFans.Models;

namespace SnookerFans.Infrastructure
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Match, MatchDto>();
        }
    }
}
