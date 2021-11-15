using System.Collections.Generic;
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

        //public IEnumerable<CountryEntity> GetAllCountries()
        //{
        //    return _repository.GetAll();
        //}

        //public CountryEntity GetCountry(int id)
        //{
        //    return _repository.Get(id);
        //}
    }
}
