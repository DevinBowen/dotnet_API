using AutoMapper;
using dotnet_API.Dtos.Character;
using dotnet_API.Models;

namespace dotnet_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}