using RestAPIBasics.Models;

namespace RestAPIBasics.Provider
{
    public interface ICountryProvider
    {
        Task<List<CountryData>?> GetAllCountries();
        Task<bool> SaveCountries(List<CountryData> countries);
        Task<List<CountryData>?> GetAllCountriesDB();
    }
}
