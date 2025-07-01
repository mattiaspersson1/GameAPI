using AutoMapper;
using Tournament.Core.Dto;
using TournamentEntity = Tournament.Core.Entities.Tournament;
using GameEntity = Tournament.Core.Entities.Game;
using Tournament.Api.Dto;

namespace Tournament.Api.Mappings
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<TournamentEntity, TournamentDto>();
            CreateMap<GameEntity, GameDto>();
            CreateMap<CreateGameDto, GameEntity>();
            CreateMap<UpdateGameDto, GameEntity>();
        }
    }
}