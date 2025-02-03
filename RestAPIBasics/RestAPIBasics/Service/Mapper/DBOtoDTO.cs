using System.Data.Common;
using RestAPIBasics.Models;

namespace RestAPIBasics.Service.Mapper
{
    public static class DBOtoDTO
    {
        public static List<ResponseAllCountries> MapCountriesDataToResponse(List<CountryData> countriesData)
        {
            List<ResponseAllCountries> responseAllCountries = [];
            foreach (var country in countriesData)
            {
                ResponseAllCountries responseCountry = new()
                {
                    Name = country.Name.Common,
                    Capital = country.Capital == null ? [] : country.Capital,
                    Borders = country.Borders == null ? [] : country.Borders
                };
                responseAllCountries.Add(responseCountry);
            }
            return responseAllCountries;
        }
    }
}
