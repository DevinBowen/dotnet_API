using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_API.Models;

namespace dotnet_API.Services.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}