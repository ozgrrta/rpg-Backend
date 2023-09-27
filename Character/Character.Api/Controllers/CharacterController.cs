using Character.Application.Services;
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
		public ActionResult<List<Domain.Models.Character>> Get()
		{
			return Ok(_characterService.GetAllCharacters());
		}

		[HttpGet("{id}")]
		public ActionResult<Domain.Models.Character> GetSingle(int id)
		{
			return Ok(_characterService.GetCharacterById(id));
		}

		[HttpPost]
		public ActionResult<List<Domain.Models.Character>> AddCharacter(Domain.Models.Character newCharacter)
		{
			return Ok(_characterService.AddCharacter(newCharacter));
		}
	}
}
