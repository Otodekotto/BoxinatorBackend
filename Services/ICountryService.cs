using BoxinatorBackend.Models;

namespace BoxinatorBackend.Services
{
    public interface ICountryService
    {
        public Task<IEnumerable<Country>> GetAllCountries();
        public Task<Country> CreateCountry(Country country);
        public Task<Country> UpdateCountry(Country country);
    }
}
