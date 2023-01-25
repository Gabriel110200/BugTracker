using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IRepositoryBase<TEntity> 
    {


        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity,bool>> filter = null);

        Task<TEntity> GetById(Guid id);

        Task AddAsync(TEntity enity);

        Task DeleteAsync(TEntity entity);

        Task Update(TEntity entity); 




    }
}
