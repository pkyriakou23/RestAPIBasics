using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RestAPIBasics.Models;

namespace RestAPIBasics.Provider.Implementation
{
    public class CountryProviderImpl : ICountryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly CountryContext _countryContext;

        public CountryProviderImpl(HttpClient httpClient, CountryContext countryContext)
        {
            _httpClient = httpClient;
            _countryContext = countryContext;
        }
        public async Task<List<CountryData>?> GetAllCountries()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,capital,borders");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<CountryData>? data = JsonSerializer.Deserialize<List<CountryData>>(jsonResponse);
                    return data;
                }
                return null;
            }
            catch (Exception)
            {
                //write to errorlogsFile for debugging
                return null;
            }

        }

        public async Task<bool> SaveCountries(List<CountryData> countries)
        {
            try
            {
                await _countryContext.CountryData.AddRangeAsync(countries);
                await _countryContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                //write to errorlogsFile for debugging
                return false;
            }
            return true;
        }

        public async Task<List<CountryData>?> GetAllCountriesDB()
        {
            try
            {
                return await _countryContext.CountryData.ToListAsync();
            }
            catch (Exception)
            {
                //write to errorlogsFile for debugging
                return null;
            }
        }
    }
}
