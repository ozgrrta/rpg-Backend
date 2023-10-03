using AutoMapper;
using Character.Domain.Dtos.Character;
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

		private readonly IMapper _mapper;

		public CharacterService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			var character = _mapper.Map<Domain.Models.Character>(newCharacter);
			character.Id = characters.Max(c => c.Id) + 1;
			characters.Add(character);

			serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			try
			{
				var character = characters.FirstOrDefault(c => c.Id == id);

				if (character == null)
				{
					throw new Exception($"Character with Id '{id}' not found.");
				}

				characters.Remove(character);

				serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

			}
			catch (Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

			var character = characters.FirstOrDefault(c => c.Id == id);

			serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

			try
			{
				var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

				if (character == null)
				{
					throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");
				}

				character.Name = updatedCharacter.Name;
				character.HitPoints = updatedCharacter.HitPoints;
				character.Strength = updatedCharacter.Strength;
				character.Defence = updatedCharacter.Defence;
				character.Intelligence = updatedCharacter.Intelligence;
				character.Class = updatedCharacter.Class;

				serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
			}
			catch (Exception ex)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = ex.Message;
			}

			return serviceResponse;
		}
	}
}
