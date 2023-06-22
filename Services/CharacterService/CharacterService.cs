using AutoMapper;
using dotnet_API.Dtos.Character;
using dotnet_API.Models;

namespace dotnet_API.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character> 
        {
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto UpdatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try {
            var character = characters.FirstOrDefault(c => c.Id == UpdatedCharacter.Id);
            if(character is null)
                throw new Exception($"Character with Id '{UpdatedCharacter.Id}' not found");

            character.Name =  UpdatedCharacter.Name;
            character.Hitpoints =  UpdatedCharacter.Hitpoints;
            character.Strength =  UpdatedCharacter.Strength;
            character.Defense =  UpdatedCharacter.Defense;
            character.Intelligence =  UpdatedCharacter.Intelligence;
            character.Class =  UpdatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            } catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}