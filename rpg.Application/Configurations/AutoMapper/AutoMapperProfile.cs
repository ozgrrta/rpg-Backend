using AutoMapper;
using rpg.Domain.Dtos.Character;
using rpg.Domain.Models;

namespace rpg.Application.Configurations.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Character, GetCharacterDto>();
			CreateMap<AddCharacterDto, Character>();
		}
	}
}
