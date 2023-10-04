using CharacterDomain.Dtos.Character;
using CharacterDomain.Models;

namespace CharacterApplication.Services
{
	public interface ICharacterService
	{
		Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
		Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
		Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
		Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
		Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id);
	}
}
