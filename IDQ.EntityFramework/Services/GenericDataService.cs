using IDQ.Domain.Base;
using IDQ.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDQ.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : ModelBase
    {

        public async Task<T> Create(T entity)
        {
            EntityEntry<T> createdResult = await context.globalDb.Set<T>().AddAsync(entity);
            _ = await context.globalDb.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await context.globalDb.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            _ = context.globalDb.Set<T>().Remove(entity);
            _ = await context.globalDb.SaveChangesAsync();

            return true;
        }

        public async Task<T> Get(int id)
        {
            T entity = await context.globalDb.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            ICollection<T> entities = await context.globalDb.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Update(int id, T entity)
        {
            entity.Id = id;
            _ = context.globalDb.Set<T>().Update(entity);
            _ = await context.globalDb.SaveChangesAsync();

            return entity;
        }
    }
}
        /*
        readonly IDQDbContextFactory _contextFactory;

        public GenericDataService(IDQDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(IDQDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                _ = await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (IDQDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                _ = context.Set<T>().Remove(entity);
                _ = await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (IDQDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (IDQDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (IDQDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                _ = context.Set<T>().Update(entity);
                _ = await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
        */