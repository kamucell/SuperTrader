using System.Linq.Expressions;
using SuperTrader.Core.Entities;

namespace SuperTrader.Core.DataAccess
{
    public interface IRepository<T> where T :  IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, int takeLineNumber = 0);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
    }
}
