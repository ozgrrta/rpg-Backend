using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Application.Services
{
	public interface ICharacterService
	{
		Task<List<Domain.Models.Character>> GetAllCharacters();
		Task<Domain.Models.Character> GetCharacterById(int id);
		Task<List<Domain.Models.Character>> AddCharacter(Domain.Models.Character newCharacter);
	}
}
