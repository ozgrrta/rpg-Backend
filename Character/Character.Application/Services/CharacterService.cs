using Character.Domain.Dtos.Character;
using Character.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Application.Services
{
	public class CharacterService : ICharacterService
	{
		private static List<Domain.Models.Character> characters = new List<Domain.Models.Character>
		{
			new Domain.Models.Character(),
			new Domain.Models.Character { Id = 1, Name = "Sam" }
		};

		public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			characters.Add(newCharacter);

			serviceResponse.Data = characters;

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			serviceResponse.Data = characters;

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			ServiceResponse<Domain.Models.Character> serviceResponse = new ServiceResponse<Domain.Models.Character>();

			var character = characters.FirstOrDefault(c => c.Id == id);

			serviceResponse.Data = character;

			return serviceResponse;
		}
	}
}
