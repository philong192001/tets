using Microsoft.EntityFrameworkCore;
using Nam.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nam.DAL.Repositories
{
    public class Repository : IRepository
    {
        public EFDbContext context;
        public Repository(EFDbContext _context)
        {
            context = _context;
        }
        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync<TEntity>(long id) where TEntity : class
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetAsync<TEntity>(long id) where TEntity : class
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }
        public bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return context.Set<TEntity>().Any(predicate);
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }
        public TEntity Get<TEntity>(long id) where TEntity : class
        {
            return context.Set<TEntity>().Find(id);
        }
        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }
    }
}
