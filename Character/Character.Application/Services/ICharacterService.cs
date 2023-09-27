using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Application.Services
{
	public interface ICharacterService
	{
		List<Domain.Models.Character> GetAllCharacters();
		Domain.Models.Character GetCharacterById(int id);
		List<Domain.Models.Character> AddCharacter(Domain.Models.Character newCharacter);
	}
}
