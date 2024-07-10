using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IRepositoryBase<TEntity>  where TEntity : class
    {


        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity,bool>> filter = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null);

        Task<TEntity> GetByIdAsync(Guid id);

        Task AddAsync(TEntity enity);

        Task DeleteAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task CommitAsync();




    }
}
