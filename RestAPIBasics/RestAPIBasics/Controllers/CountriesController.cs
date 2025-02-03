using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIBasics.Models;
using RestAPIBasics.Service;

namespace RestAPIBasics.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>A list of country information.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _countryService.GetCountriesAsync());
        }
    }
}
