using AutoMapper;
using rpg.Domain.Dtos.Character;
using rpg.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
