using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace ServicesLayer.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
