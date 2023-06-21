using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_API.Models;

namespace dotnet_API.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}