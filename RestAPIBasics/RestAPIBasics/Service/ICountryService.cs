using RestAPIBasics.Models;

namespace RestAPIBasics.Service
{
    public interface ICountryService
    {
        Task<IEnumerable<ResponseAllCountries>?> GetCountriesAsync();
    }
}
