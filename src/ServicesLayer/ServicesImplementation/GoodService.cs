using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;
using ServicesLayer.Repository;
using ServicesLayer.Services;

namespace ServicesLayer.ServicesImplementation
{
    public class GoodService : IGoodService
    {
        private IRepository<GoodEntity> _repository;

        public GoodService(IRepository<GoodEntity> repository)
        {
            _repository = repository;
        }

        public Task<List<GoodEntity>> ListAsync()
        {
            return _repository.GetAllAsync();
        }
        public Task<GoodEntity> GetAsync(int id)
        {
            return _repository.GetAsync(id);
        }

        public Task<int> AddAsync(GoodEntity goodEntity)
        {
            return _repository.AddAsync(goodEntity);

        }

        public Task UpdateAsync(GoodEntity goodEntity)
        {
            return _repository.UpdateAsync(goodEntity);
        }

        public Task DeleteAsync(int id)
        {
            var goodEntity = _repository.GetAsync(id);
            return _repository.DeleteAsync(goodEntity.Result);
        }
    }
}
