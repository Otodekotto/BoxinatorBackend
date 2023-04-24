using AutoMapper;
using BoxinatorBackend.Models;
using BoxinatorBackend.Models.DTO.CountryDtos;

namespace BoxinatorBackend.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<PostCountryDTO, Country>();
            CreateMap<PutCountryDTO, Country>();
            CreateMap<Country, GetCountryDTO>();
        }
    }
}
