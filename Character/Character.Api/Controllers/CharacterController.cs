using Character.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Character.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		private static List<Models.Character> characters = new List<Models.Character>
		{
			new Models.Character(),
			new Models.Character { Id = 1, Name = "Sam" }
		};

		[HttpGet("GetAll")]
		public ActionResult<List<Models.Character>> Get()
		{
			return Ok(characters);
		}

		[HttpGet("{id}")]
		public ActionResult<Models.Character> GetSingle(int id)
		{
			return Ok(characters.FirstOrDefault(c => c.Id == id));
		}

		[HttpPost]
		public ActionResult<List<Models.Character>> AddCharacter(Models.Character newCharacter)
		{
			characters.Add(newCharacter);

			return Ok(characters);
		}
	}
}
