using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rpg.Application.Interfaces;
using rpg.Domain.Dtos.Character;
using rpg.Domain.Models;

namespace rpg.Api.Controllers
{
    [ApiController]
	[Route("api/[controller]/[action]")]
	public class CharacterController : ControllerBase
	{
		private readonly ICharacterService _characterService;

		public CharacterController(ICharacterService characterService)
		{
			_characterService = characterService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
		{
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
		{
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			var response = await _characterService.UpdateCharacter(updatedCharacter);

			if (response.Data == null)
			{
				return NotFound(response);
			}

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
		{
			var response = await _characterService.DeleteCharacters(id);

			if (response.Data == null)
			{
				return NotFound(response);
			}

			return Ok(response);
		}
	}
}
