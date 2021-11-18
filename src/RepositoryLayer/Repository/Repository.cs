using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Repository;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _DbContext;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
            entities = _DbContext.Set<T>();
        }

        public async Task<T> GetAsync(int Id)
        {
            return await entities.FindAsync(Id);

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            return await _DbContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
        {
            return _DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await _DbContext.SaveChangesAsync();
        }
        public Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            return _DbContext.SaveChangesAsync();
        }
    }
}
