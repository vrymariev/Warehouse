using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServicesLayer.Services
{
    public interface ICountryService
    {
        Task<List<CountryEntity>> ListAsync();
    }
}
