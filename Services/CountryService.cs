using BoxinatorBackend.Data;
using BoxinatorBackend.Exceptions;
using BoxinatorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxinatorBackend.Services
{
    public class CountryService : ICountryService
    {
        private readonly BoxinatorDbContext _context;

        public CountryService(BoxinatorDbContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateCountry(Country country)
        {
            _context.Countrys.Add(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _context.Countrys.ToListAsync();
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var foundCountry = await _context.Countrys.AnyAsync(x => x.Id == country.Id);
            if (!foundCountry)
            {
                throw new PackageNotFoundException(country.Id);
            }
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return country;
        }
    }
}
