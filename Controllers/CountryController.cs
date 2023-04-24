using AutoMapper;
using BoxinatorBackend.Exceptions;
using BoxinatorBackend.Models;
using BoxinatorBackend.Models.DTO.CountryDtos;
using BoxinatorBackend.Models.DTO.PackageDtos;
using BoxinatorBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BoxinatorBackend.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("Country")]
        public async Task<ActionResult<GetCountryDTO>> GetAllCountries()
        {
            return Ok(_mapper.Map<IEnumerable<GetCountryDTO>>(await _countryService.GetAllCountries()));
        }


        [HttpPost("Country")]
        public async Task<ActionResult<Country>> PostCountry(PostCountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);

            await _countryService.CreateCountry(country);

            return CreatedAtAction(nameof(GetAllCountries), new { id = country.Id }, country);
        }

        [HttpPut("Country/{id}")]
        public async Task<IActionResult> PutCountry(int id, PutCountryDTO putCountryDto)
        {
            if (id != putCountryDto.Id)
            {
                return BadRequest();
            }

            try
            {
                Country country = _mapper.Map<Country>(putCountryDto);
                await _countryService.UpdateCountry(country);
            }
            catch (CountryNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
    }
}
