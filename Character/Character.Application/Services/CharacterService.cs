using AutoMapper;
using CharacterDomain.Dtos.Character;
using CharacterDomain.Models;
using CharacterPersistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApplication.Services
{
	public class CharacterService : ICharacterService
	{
		private readonly IMapper _mapper;
		private readonly CharacterContext _characterContext;

		public CharacterService(IMapper mapper, CharacterContext characterContext)
		{
			_mapper = mapper;
			_characterContext = characterContext;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			var character = _mapper.Map<Character>(newCharacter);
			character.Id = _characterContext.Characters.Max(c => c.Id) + 1;

			await _characterContext.Characters.AddAsync(character);
			await _characterContext.SaveChangesAsync();

			serviceResponse.Data = await _characterContext.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
		{
			ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

			try
			{
				var character = await _characterContext.Characters.FirstOrDefaultAsync(c => c.Id == id);

				if (character == null)
				{
					throw new Exception($"Character with Id '{id}' not found.");
				}

				_characterContext.Characters.Remove(character);

				serviceResponse.Data = await _characterContext.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

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

			var dbCharacters = await _characterContext.Characters.ToListAsync();

			serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

			var character = await _characterContext.Characters.FirstOrDefaultAsync(c => c.Id == id);

			serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

			try
			{
				var character = await _characterContext.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

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
