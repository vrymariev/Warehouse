using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warehouse.Controllers
{
    [Route("countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<List<CountryEntity>> List()
        {
            return await _countryService.ListAsync();
        }
    }
}
