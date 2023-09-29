using AutoMapper;
using Character.Domain.Dtos.Character;

namespace Character.Application.Configurations.AutoMapper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Domain.Models.Character, GetCharacterDto>();
			CreateMap<AddCharacterDto, Domain.Models.Character>();
		}
	}
}
