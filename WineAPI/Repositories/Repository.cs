using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly WineServiceContext db;

        public Repository(WineServiceContext context)
        {
            db = context;
        }

        public async Task<T> Add(T entity)
        {
            db.Set<T>().Add(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return db.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>()
                .Where(predicate).AsNoTracking();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }
    }
}
