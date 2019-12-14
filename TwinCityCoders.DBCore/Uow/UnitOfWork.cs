using Microsoft.EntityFrameworkCore;
using TwinCityCoders.DBCore.Context.EFContext;
using TwinCityCoders.DBCore.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwinCityCoders.DBCore.Repositories.Interfaces;
using TwinCityCoders.DBCore.Repositories.Base;

namespace TwinCityCoders.DBCore.Uow
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDatabaseContext dbContext;
        private readonly DatabaseContext _dBConnectionContext;

        private Dictionary<Type, object> repos;

        public UnitOfWork(IContextFactory contextFactory, DatabaseContext dBConnectionContext)
        {
            dbContext = contextFactory.DbContext;
            _dBConnectionContext = dBConnectionContext;
        }
        public List<TEntity> SpRepository<TEntity>(string SpName, params object[] parameters) where TEntity : class
        {
            return _dBConnectionContext.Set<TEntity>().FromSqlRaw(SpName, parameters).ToList<TEntity>();
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(dbContext);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return dbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}
