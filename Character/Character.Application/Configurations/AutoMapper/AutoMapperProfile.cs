using AutoMapper;
using CharacterDomain.Dtos.Character;
using CharacterDomain.Models;

namespace CharacterApplication.Configurations.AutoMapper
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
