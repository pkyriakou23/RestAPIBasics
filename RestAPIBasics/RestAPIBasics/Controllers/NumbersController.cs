using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIBasics.Models;
using RestAPIBasics.Service;

namespace RestAPIBasics.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        private readonly INumbersService _numbersService;

        public NumbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        /// <summary>
        /// Retrieves the second largest distinct number from an array provided in the request body.
        /// </summary>
        /// <param name="body">The request body containing an array of numbers</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetSecondLargest([FromBody] RequestObj body)
        {
            if (body?.RequestArrayObj == null || body.RequestArrayObj.Count() < 2)
            {
                return BadRequest("Array must contain at least two numbers.");
            }
            ResponseObj response = new();
            response.SecondLargest = _numbersService.GetSecondLargest(body.RequestArrayObj);
            if (response.SecondLargest == null)
            {
                return BadRequest("Array must at least two distinct numbers.");
            }
            
            return Ok(response);
        }
    }
}
