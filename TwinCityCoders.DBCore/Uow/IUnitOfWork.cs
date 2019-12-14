using System.Collections.Generic;
using System.Threading.Tasks;
using TwinCityCoders.DBCore.Repositories.Interfaces;

namespace TwinCityCoders.DBCore.Uow
{
    public interface IUnitOfWork
    {
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        /// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
        Task<int> CommitAsync();
        /// <returns>Repository</returns>
        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        public List<TEntity> SpRepository<TEntity>(string SpName, params object[] parameters) where TEntity : class;

    }
}
