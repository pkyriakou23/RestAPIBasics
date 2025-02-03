using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;
using RestAPIBasics.Models;
using RestAPIBasics.Provider;
using RestAPIBasics.Service.Mapper;

namespace RestAPIBasics.Service.Implementation
{
    public class CountryServiceImpl : ICountryService
    {
        private readonly ICountryProvider _countryProvider;
        private readonly IMemoryCache _cache;
        private readonly string _cacheKey = "CountriesCacheKey";

        public CountryServiceImpl(ICountryProvider countryProvider, IMemoryCache cache)
        {
            _countryProvider = countryProvider;
            _cache = cache;
        }
        public async Task<IEnumerable<ResponseAllCountries>> GetCountriesAsync()
        {
            if (_cache.TryGetValue(_cacheKey, out List<ResponseAllCountries> countries))
            {
                return countries;
            }

            List<ResponseAllCountries> response = [];
            List<CountryData>? data = await GetCountriesFromDB();
            if (data != null && data.Count > 0)
            {
                response = DBOtoDTO.MapCountriesDataToResponse(data);
                _cache.Set(_cacheKey, response);
                return response;
            }

            data = await _countryProvider.GetAllCountries();
            if (data == null)
            {
                throw new HttpRequestException("Internal Server Error", null, HttpStatusCode.InternalServerError);
            }
            await SaveCountriesToDB(data);
            response = DBOtoDTO.MapCountriesDataToResponse(data);
            _cache.Set(_cacheKey, response);
            return response;
        }

        public async Task SaveCountriesToDB(List<CountryData> data)
        {
            await _countryProvider.SaveCountries(data);
            // log error that the data is not saved, no need to mention it to client
        }

        public async Task<List<CountryData>?> GetCountriesFromDB()
        {
            return await _countryProvider.GetAllCountriesDB();
        }
    }
}
