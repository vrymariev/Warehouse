using DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public interface IManufacturerService
    {
        Task<List<ManufacturerEntity>> ListAsync();
        Task<ManufacturerEntity> GetAsync(int id);
        Task<int> AddAsync(ManufacturerEntity manufacturerEntity);
        Task UpdateAsync(ManufacturerEntity manufacturerEntity);
        Task DeleteAsync(int id);
    }
}
