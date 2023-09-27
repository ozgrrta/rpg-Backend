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

		public async Task<ServiceResponse<List<Domain.Models.Character>>> AddCharacter(Domain.Models.Character newCharacter)
		{
			ServiceResponse<List<Domain.Models.Character>> serviceResponse = new ServiceResponse<List<Domain.Models.Character>>();

			characters.Add(newCharacter);

			serviceResponse.Data = characters;

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<Domain.Models.Character>>> GetAllCharacters()
		{
			ServiceResponse<List<Domain.Models.Character>> serviceResponse = new ServiceResponse<List<Domain.Models.Character>>();

			serviceResponse.Data = characters;

			return serviceResponse;
		}

		public async Task<ServiceResponse<Domain.Models.Character>> GetCharacterById(int id)
		{
			ServiceResponse<Domain.Models.Character> serviceResponse = new ServiceResponse<Domain.Models.Character>();

			var character = characters.FirstOrDefault(c => c.Id == id);

			serviceResponse.Data = character;

			return serviceResponse;
		}
	}
}
