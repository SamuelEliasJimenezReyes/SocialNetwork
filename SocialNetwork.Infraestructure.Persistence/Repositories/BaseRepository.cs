using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infraestructure.Persistence.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _dbContext;

        public BaseRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).Property("IsDeleted").CurrentValue = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity, int id)
        {
            var entry = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
