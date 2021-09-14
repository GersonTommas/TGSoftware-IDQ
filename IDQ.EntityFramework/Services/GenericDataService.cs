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
            T newEntity = context.globalDb.Set<T>().CreateProxy();
            context.globalDb.Entry(newEntity).CurrentValues.SetValues(entity);

            EntityEntry<T> createdResult = await context.globalDb.Set<T>().AddAsync(newEntity);
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
        }/*

        async Task<productoModel> saveMe(ModelBase sentModelBase)
        {
            productoModel procesedModelBase = sentModelBase as productoModel;

            productoModel clone = context.globalDb.productos.CreateProxy();

            clone.Activo = procesedModelBase.Activo;
            clone.Codigo = procesedModelBase.Codigo;
            clone.Descripcion = procesedModelBase.Descripcion;
            clone.FechaModificado = procesedModelBase.FechaModificado;
            clone.FechaModificadoID = procesedModelBase.FechaModificadoID;
            clone.Medida = procesedModelBase.Medida;
            clone.MedidaID = procesedModelBase.MedidaID;
            clone.PrecioActual = procesedModelBase.PrecioActual;
            clone.PrecioIngreso = procesedModelBase.PrecioIngreso;
            clone.Stock = procesedModelBase.Stock;
            clone.StockInicial = procesedModelBase.StockInicial;
            clone.Tag = procesedModelBase.Tag;
            clone.TagID = procesedModelBase.TagID;

            return clone;
        }*/
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