using Character.Application.Services;
using Character.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Character.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		private readonly ICharacterService _characterService;

		public CharacterController(ICharacterService characterService)
		{
			_characterService = characterService;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<ServiceResponse<List<Domain.Models.Character>>>> Get()
		{
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceResponse<Domain.Models.Character>>> GetSingle(int id)
		{
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<Domain.Models.Character>>>> AddCharacter(Domain.Models.Character newCharacter)
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
		}
	}
}
