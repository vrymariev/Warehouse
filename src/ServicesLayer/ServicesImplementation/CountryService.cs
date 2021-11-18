using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;
using ServicesLayer.Repository;
using ServicesLayer.Services;

namespace ServicesLayer.ServicesImplementation
{
    public class CountryService : ICountryService
    {
        private IRepository<CountryEntity> _repository;

        public CountryService(IRepository<CountryEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<CountryEntity>> ListAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
