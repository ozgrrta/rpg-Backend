using Character.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Application.Services
{
	public interface ICharacterService
	{
		Task<ServiceResponse<List<Domain.Models.Character>>> GetAllCharacters();
		Task<ServiceResponse<Domain.Models.Character>> GetCharacterById(int id);
		Task<ServiceResponse<List<Domain.Models.Character>>> AddCharacter(Domain.Models.Character newCharacter);
	}
}
