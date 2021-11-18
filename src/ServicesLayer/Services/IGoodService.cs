using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServicesLayer.Services
{
    public interface IGoodService
    {
        Task<List<GoodEntity>> ListAsync();
        Task<GoodEntity> GetAsync(int id);
        Task<int> AddAsync(GoodEntity goodEntity);
        Task UpdateAsync(GoodEntity goodEntity);
        Task DeleteAsync(int id);
    }
}
