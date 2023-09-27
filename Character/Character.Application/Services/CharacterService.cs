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

		public List<Domain.Models.Character> AddCharacter(Domain.Models.Character newCharacter)
		{
			characters.Add(newCharacter);

			return characters;
		}

		public List<Domain.Models.Character> GetAllCharacters()
		{
			return characters;
		}

		public Domain.Models.Character GetCharacterById(int id)
		{
			var character = characters.FirstOrDefault(c => c.Id == id);

			if (character != null)
			{
				return character;
			}

			throw new Exception("Character not found");
		}
	}
}
