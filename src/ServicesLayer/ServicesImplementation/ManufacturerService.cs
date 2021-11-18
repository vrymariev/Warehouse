using DomainLayer.Models;
using ServicesLayer.Repository;
using ServicesLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesLayer.ServicesImplementation
{
    public class ManufacturerService : IManufacturerService
    {
        private IRepository<ManufacturerEntity> _repository;

        public ManufacturerService(IRepository<ManufacturerEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<ManufacturerEntity>> ListAsync()
        {
            return _repository.GetAllAsync();
        }
        public Task<ManufacturerEntity> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<int> AddAsync(ManufacturerEntity manufacturerEntity)
        {
            return _repository.AddAsync(manufacturerEntity);
        }

        public Task UpdateAsync(ManufacturerEntity manufacturerEntity)
        {
            return _repository.UpdateAsync(manufacturerEntity);
        }

        public Task DeleteAsync(int id)
        {
            var manufacturerEntity = _repository.GetAsync(id);
            return _repository.DeleteAsync(manufacturerEntity.Result);
        }
    }
}
